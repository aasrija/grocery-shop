using System;
using System.IO;
using System.Net;
using System.Collections.Generic;


namespace Client
{
    public class WebReq
    {

        // put this all into function to make it easier
        public string getResp(string url){
          WebRequest req = WebRequest.Create(url);
          req.Credentials = CredentialCache.DefaultCredentials;
          WebResponse resp = req.GetResponse();
          
          using (Stream dataStream = resp.GetResponseStream())
          {   
            StreamReader reader = new StreamReader(dataStream);

            string respfromServer = reader.ReadToEnd();

            return respfromServer;
        
          } 

        //  resp.Close();

        }

        public static void Main()
        {

            WebReq wr = new WebReq();

            
            Console.WriteLine("Enter username: ");
            string clientname = Console.ReadLine();
            string url = "http://py1:5000/GroceryShoppingServer/addClient?clientname="+clientname;
            Console.WriteLine(wr.getResp(url));
        
            bool loop = true;

            while (loop) {
                Console.WriteLine("\n------------------------------------------");
                Console.WriteLine("Buy a Veggie or Fruit at My Market!");
                Console.WriteLine("Items Available: broccoli, carrot, spinach, apple, banana, orange");
                Console.WriteLine("Enter the item you would like to buy :)");
                Console.WriteLine("t Total");
                Console.WriteLine("c Check-Out");
                Console.WriteLine("x Leave Shop");

                string command = Console.ReadLine();

                // gets item input and sends to server along with clientname
                if(command.Equals("broccoli") || command.Equals("carrot") || command.Equals("spinach") || command.Equals("apple")|| command.Equals("banana") || command.Equals("orange")){
                    url = "http://py1:5000/GroceryShoppingServer/addToCart?clientname="+clientname+"&item="+command;
                    Console.WriteLine(wr.getResp(url));

                }

                 // sends clietname to server to get curr total
                if(command.Equals("t"))
                {
                    url = "http://py1:5000/GroceryShoppingServer/total?clientname="+clientname;
                    Console.WriteLine("\nTotal: " + wr.getResp(url));
                }

                // sends clietname to server to get resceipt
                // prompts user if they want to leave
                if(command.Equals("c"))
                {
                    url = "http://py1:5000/GroceryShoppingServer/receipt?clientname="+clientname;
                    Console.Write(wr.getResp(url));
            
                    Console.WriteLine("\nEnter x to leave shop");
                
                    string message = Console.ReadLine();
                    if (message.Equals("x")){
                        command = "x";
                    }
                }
                // x ot leave server
                if(command.Equals("x"))
                {
                    Console.WriteLine("leaving shop..");
                    loop = false;
                }

              }
        }
    }
}
