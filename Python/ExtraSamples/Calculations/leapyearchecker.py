year = int(input("Which year do you want to check?\n"))

#After referencing a calculation on how often a leap year happens
if  year % 4 == 0:
    if year % 100 != 0 or year % 400 == 0:
        print("This is a leap year")
    else:
        print("This is not a leap year")
else:
    print("This is not a leap year")
