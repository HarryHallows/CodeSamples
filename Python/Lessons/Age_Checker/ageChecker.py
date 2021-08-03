#age variable that checks for input from the user
age = int(input("What is your age?\n")) #converts the input into an integer from a string

#checks for the users inputted age

#if the user is below 3
if age < 3:
    #then call print of baby
    print("ITS A BABY")
#if the user is 12 or below and over 3 then it's a child    
elif age <= 12:
    #calling child print
    print("its a child!")
elif age <= 18:
    print("teenager")
elif age <= 30:
    print("young adult")
else:
    print("damn you're ancient")


if age < 10 or age > 15:
   print("random words")

