
from tokenize import String
from flask import Flask
from flask import request, jsonify
from collections import Counter
import time

app = Flask(__name__)

checkOuttime = 0
clients = []
customerInfo = {}
catalogue = {"broccoli":3.99,"carrot":2.99,"spinach":1.99,"apple":0.99,"banana":0.99,"orange":0.99}


@app.route("/GroceryShoppingServer")
def welcome():
    return "<p> Welcome to the Grocery Market </p>"

# add client function
@app.route("/GroceryShoppingServer/addClient", methods=['GET'])
def addClient():

    success = False
    clientname = request.args['clientname']

    clients.append(clientname)
    customerInfo.update({clientname:[]}) # update customers cart info
    
    # chack is clients are added
    for c in clients:
        if c == clientname:
            success = True
        else:
            success = False
    if success == True:
        return clientname + " has entered the server!"
    else:
        return "ERROR: " +clientname + " was unable to be added into server"

# adds item to cart
@app.route("/GroceryShoppingServer/addToCart", methods=['GET'])
def addToCart():
    clientname = request.args['clientname']
    item = request.args['item']
   # try:
    customerInfo[clientname].append(item)
        # check if item is in customer info
    if item in customerInfo[clientname]:
        return item+ " added to cart"
    else: 
  #  except:
        return "Unable to add "+item+" to cart"
    
# gets the total by calculating here
@app.route("/GroceryShoppingServer/total", methods=['GET'])
def totalCost():

    clientname = request.args['clientname']
    total = 0.0
   
    if len(customerInfo[clientname]) > 0:
        for i in customerInfo[clientname]:
            total = total + catalogue[i]

        return format(total, "0.2f") # format to 2 decimal places
    else:

        return str(total)
   
        
# prints receipt at checkout
@app.route("/GroceryShoppingServer/receipt", methods=['GET'])
def checkOut():

    clientname = request.args['clientname']
    if len(customerInfo[clientname]) > 0:
        receipt = "\n------------------------------------------"
        receipt = "Thank you for shopping with us "+clientname+"! Here is your receipt:\n"
        cost = totalCost()
        cart = customerInfo[clientname]
        itemCount = {} # dictionary for item and their count
        itemCount.update(Counter(cart)) # count num of each items to print
        for i in itemCount.keys():
            receipt = receipt+i+" x"+str(itemCount[i])+"\n"
        receipt = receipt+"\n" +cost+ "\n------------------------------------------\n"
    else:
        receipt = "cart is empty! \n\n\nEnter < to go back to shopping"    
    
    return receipt

