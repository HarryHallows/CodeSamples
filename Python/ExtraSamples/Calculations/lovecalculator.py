yourName = input("Enter your name\n")
yourCrushName = input("Now enter your crush's name\n")

finalNames = (yourName + yourCrushName).lower()

trueLove = "true love"


#Fast way to calculate the values of the different input variables
t = (trueLove + finalNames).count("t")
r = (trueLove + finalNames).count("r")
u = (trueLove + finalNames).count("u")
e = (trueLove + finalNames).count("e")

l = (trueLove + finalNames).count("l")
o = (trueLove + finalNames).count("o")
v = (trueLove + finalNames).count("v")
e = (trueLove + finalNames).count("e")

#Totalling up the 'true love' values into a single variable that we can compare later
loveScore = t + r + u + e + l + o + v + e 

#Calculating a simple silly way of what your real love score is by adding up your name and your crush's names together against "true love"
if loveScore >= 90 :
    print(f"Your score is {loveScore}%, and were born to be together!")
elif loveScore < 90 and loveScore > 50:
    print(f"Your score is {loveScore}%, which you both go together okay")
elif loveScore < 50 and loveScore > 20:
    print(f"Your love score is {loveScore}%, you can try your chances...")
else:
    print(f"Your love percentage is {loveScore}%, you're both doomed to be. Save yourself the time and find someone better!")
