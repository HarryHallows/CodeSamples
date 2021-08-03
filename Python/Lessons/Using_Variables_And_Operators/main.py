#string food = "burger";
food = "burger"

#int age = 24;
age = 24

# if(food == "burger")
# {
#   
# }


if(food == "burger"):   
    age = 20
    if(age == 20):
        food = "bad"

nest = True
eggs = 0


if(nest == True):
    eggs = 4


clothes = "Trouser"
isNaked = True
isWearing = True
howManyLegs = 2
priceOfClothes = 0

# checking IF clothes are EQUAL to "Trouser"?
if(clothes == "Trouser"):
    # In python we indent to nest the outcome 
    # information of an IF statement
    # setting the price of the current peice of clothes
    priceOfClothes = 9.99


# and # is an operator that checks two or more conditions are met
# or # is an operator that checks atleast one of the following conditions are met
# == #is an operator that checks if a condition is EQUAL to the condition in question
# != #is an operator that checks if a condition is NOT EQUAL to the condition in question

#checking to see if we have trousers and are now wearing them
if(clothes != "Trouser" and isWearing == True):
    #if we happen to be wearing trousers then no one can see our underwear  
    #because we're not longer naked
    isNaked = False
    clothes = "Shirt"


if(clothes == "Trouser" or clothes == "Shirt"):
    print("I have a shirt or trousers on!!!!")


#Homework
    # Todo: 
    #   Convert last weeks homework into python
    #   Use a new example of variables and conditions to write a version of all the operators in action

    # CHALLENGE:
    #   Use the new example variables to try the print() function  
    #   Use the new examples to use try the input() function