import os
for dirpath, _, files in os.walk('.'):
    for file in files:
        if file == 'desktop.ini':
            os.remove(os.path.join(dirpath, file))