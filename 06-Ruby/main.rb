def f n
  if n>0
    (1..n).inject { |a, b| a*b }
  else
    raise "Runtime error: cannot count factorial for nonpositive number"
  end
end

module InstanceModule
   def square
    self*self
  end
end

module ClassModule
  def sample n
    if n>0
      Array.new(n) { rand(0..n) }
    else
      raise ArgumentError.new "ArgumentError: the number must be positive"
    end
  end
  alias :random :sample
end
  
class Integer
  include InstanceModule
  extend ClassModule
  def factorial
    f self
  end
  
  def hours
    self*60
  end
  def minutes
    self
  end
  def seconds
    self/100.0
  end
end

def min_max arr
  sorted = arr.sort
  "#{sorted.first(4).sum} #{sorted.last(4).sum}"
end

def decimal n
  if n.count('01') == n.size
    n.to_i 2
  else
    raise ArgumentError.new "ArgumentError: this is not a binary number"
  end
end

def count_words s
  s.split(" ").inject(Hash.new(0)) { |counts, e| counts[e] += 1 ; counts}
end

def pangram? line
  ('a'..'z').all? { |letter| line.downcase.include? (letter) }
end

class Clock
  attr_reader :hour, :minute, :second
  def initialize(hour, minute, second)
    @hour, @minute, @second = hour, minute, second
  end

  def print
    puts "The current time is #{format('%02d', hour)}:#{format('%02d', minute)}:#{format('%02d', second)}"
  end

  def + time
    moveS = (time-time.floor).round(2)*100
    moveM = ((@second+moveS)/60).floor+time.floor%60
    moveH = ((@minute+moveM)/60).floor+(time/60).floor
      Clock.new(
      (@hour+moveH)%24, 
      (@minute+moveM)%60,
      (@second+moveS)%60
    )
  end

  def == obj
    hour==@hour && minute==@minute && second==@second
  end
  
  def self.measure_time
    start = Time.now
    yield
    puts "Result: #{(Time.now - start).round} seconds elapsed"
  end
end

p f 5  # 120
#p f -1 # Runtime error: cannot count factorial for negative number
p 5.factorial  # 120
#p -1.factorial # Runtime error: cannot count factorial for negative number
p 5.square  # 25
p Integer.sample(5)   # e.g. [3, 4, 3]
# p Integer.sample(-1)  # ArgumentError: the number must be positive
p Integer.random(5)   # e.g. [3, 4, 3]
#p Integer.random(-1)  # ArgumentError: the number must be positive
p min_max([1, 2, 3, 4, 5])  # 10 15
p min_max([2, 8, 3, 5, 1])  # 11 18
p decimal("101")  # 5
#p decimal("231")  # ArgumentError: this is not a binary number
p count_words("olly olly come here free")
p pangram?("The quick brown fox jumps over the lazy dog.")  # true
p pangram?("abde")                                          # false
clock = Clock.new(1, 2, 3)
clock.print  # The current time is 01:02:03
clock += 123.45
clock.print  # The current time is 03:05:48
p clock == Clock.new(3, 5, 48)  # true
Clock.measure_time do
  puts "Something is happening here"
  sleep 3
end# Result: 3 seconds elapsed
clock += 10.hours
clock.print  # The current time is 13:05:48
nil