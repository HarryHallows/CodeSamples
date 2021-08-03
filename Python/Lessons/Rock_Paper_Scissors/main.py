import random

#Example Pseudo code for class

#REQUIRED VARIABLES: Rock, Paper and Scissors 

rock = ''' 
   _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
'''
paper = ''' 
  _______
---'   ____)____
          ______) 
          _______) 
         _______) 
---.__________) 
'''

scissors = ''' 
    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)
'''

gameImages = [rock, paper, scissors] #rock = 0 paper = 1 scissors = 2 because we don't have 4 items we can't check for the value 3

#STEP 2: Input from the player choice 

playersChoice = int(input("Write 0 for Rock, 1 for Paper and 2 for Scissors.\n"))

print(gameImages[playersChoice])

#STEP 3: computer choice 

computersChoice = random.randint(0, 2)

print("Computer chose:\n" + f"{gameImages[computersChoice]}")

#STEP 4: Logic for the choices 
