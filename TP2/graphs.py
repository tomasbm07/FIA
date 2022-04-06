import os
import numpy as np
import matplotlib.pyplot as plt


if __name__ == '__main__':
    
    path = "/home/tomasbm/Desktop/EvolvingCars/Results"
    
    for i in os.listdir(path):
        files = os.listdir(f"{path}/{i}")
        
        if files == []:
            continue
            
        log = np.genfromtxt(f"{path}/{i}/{files[1]}", delimiter = ',')
        print(log)
        
        plt.figure()
        plt.plot(log)
        plt.show()
        