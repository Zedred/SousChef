#Q15.1 - Part 2
#Optimization of the 'diet problem'

from pulp import *
import pandas as pd

#Set directory to import diet file
os.chdir('E:\\Documents_Interesting\\Fitness')

file = r'Meals.xlsx'
RawData = pd.read_excel(file)

#Subsetting raw data file into just food library...
FoodLibrary = RawData[2:]

#...and the min/max daily intake amounts
CalorieCount = RawData.iloc[[0, 1], [1]]
CarbCount = RawData.iloc[[0, 1], [2]]
FatCount = RawData.iloc[[0, 1], [3]]
ProteinCount = RawData.iloc[[0, 1], [4]]

#Converting to list format
FoodLibrary =  FoodLibrary.values.tolist()

#Initialize
Food = [x[0] for x in FoodLibrary]

#Making dictionaries for all columns (except serving size)
#Key is Food Item to Pair with Variable
Calorie = dict([(x[0], float(x[1])) for x in FoodLibrary])
Carb = dict([(x[0], float(x[2])) for x in FoodLibrary])
Fat = dict([(x[0], float(x[3])) for x in FoodLibrary])
Protein = dict([(x[0], float(x[4])) for x in FoodLibrary])
MealType = dict([(x[0], str(x[5])) for x in FoodLibrary])

#Creating problem variable to contain the problem data
#Minimize Total Cost of Diet While Meeting Nutritional Requirements
Problem = LpProblem("The Diet Problem", LpMinimize)

#Creating variables for the problem
AmountFood = LpVariable.dicts("Amount of Food", Food, 0, None, LpInteger)
FoodSelected = LpVariable.dicts("If Food was selected", Food, 0, 1, LpBinary)

#Creating objective function for the problem
Problem += lpSum([AmountFood[i] * Calorie[i] for i in Food]), "Total Calories of Diet"

#Creating constraints for the problem
#Problem += lpSum([AmountFood[i] * Calorie[i] for i in Food]) >= CalorieCount.iloc[0], "Min. Calories"
#Problem += lpSum([AmountFood[i] * Calorie[i] for i in Food]) <= CalorieCount.iloc[1], "Max. Calories"
Problem += lpSum([AmountFood[i] * Fat[i] for i in Food]) >= FatCount.iloc[0], "Min. Fat"
Problem += lpSum([AmountFood[i] * Fat[i] for i in Food]) <= FatCount.iloc[1], "Max. Fat"
Problem += lpSum([AmountFood[i] * Carb[i] for i in Food]) >= CarbCount.iloc[0], "Min. Carb"
Problem += lpSum([AmountFood[i] * Carb[i] for i in Food]) <= CarbCount.iloc[1], "Max. Carb"
Problem += lpSum([AmountFood[i] * Protein[i] for i in Food]) >= ProteinCount.iloc[0], "Min. Protein"
Problem += lpSum([AmountFood[i] * Protein[i] for i in Food]) <= ProteinCount.iloc[1], "Max. Protein"

for i in Food:
    Problem += AmountFood[i] >= 0.1 * FoodSelected[i]
    Problem += AmountFood[i] <= 2.0 * FoodSelected[i]

Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Breakfast') for i in Food]) >= 1, "Min breakfast"
Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Breakfast') for i in Food]) <= 4, "Max breakfast"
#Problem += lpSum([FoodSelected[i] * AmountFood[i] * (MealType[i] == 'Breakfast') for i in Food]) <= 1, "Breakfast quantity constraint"

Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Snack') for i in Food]) == 0, "No snacks"
#Problem += lpSum([FoodSelected[i] * AmountFood[i] * (MealType[i] == 'Snack') for i in Food]) <= 2, "Snack quantity constraint"

Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Shake') for i in Food]) == 0, "No shakes"
#Problem += lpSum([FoodSelected[i] * AmountFood[i] * (MealType[i] == 'Shake') for i in Food]) <= 2, "Shake quantity constraint"

Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Main') for i in Food]) >= 1, "Min entree"
Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Main') for i in Food]) <= 4, "Max entree"
#Problem += lpSum([FoodSelected[i] * AmountFood[i] * (MealType[i] == 'Entree') for i in Food]) <= 2, "Entree quantity constraint"

Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Side') for i in Food]) >= 1, "Min sides"
Problem += lpSum([FoodSelected[i] * (MealType[i] == 'Side') for i in Food]) <= 4, "Max sides"
#Problem += lpSum([FoodSelected[i] * AmountFood[i] * (MealType[i] == 'Side') for i in Food]) <= 2, "Side quantity constraint"

#Solving the problem
Problem.solve()

#Printing the results
print("Status:", LpStatus[Problem.status])
for v in Problem.variables():
    if v.varValue > 0 and "Amount" in v.name:
        print(v.name, "=", v.varValue)
    else:
        pass
print("Total daily calories = %.2f" % value(Problem.objective))

totalCalories = 0
totalProtein = 0
totalCarbs = 0
totalFats = 0

for i in Food:
    totalCalories   += AmountFood[i].varValue * Calorie[i]
    totalProtein    += AmountFood[i].varValue * Protein[i]
    totalCarbs      += AmountFood[i].varValue * Carb[i]
    totalFats       += AmountFood[i].varValue * Fat[i]

print("Total calories   = %.2f" % totalCalories)
print("Total protein    = %.2f" % totalProtein)
print("Total carbs      = %.2f" % totalCarbs)
print("Total fats       = %.2f" % totalFats)
