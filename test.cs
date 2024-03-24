using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Diagnostics;

namespace Client
{
    public class WebReq
    {

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

       //   resp.Close();

        }

        public static void Main()
        {

            List<string> items = new List<string>(){"broccoli","carrot", "spinach", "apple", "banana", "orange"};

            WebReq wr = new WebReq();
           

           

            var s1 = new Stopwatch();
            var totTimeA = new Stopwatch();
            long tA = 0;
            
            string url = "http://py1:5000/GroceryShoppingServer/addClient?clientname=azi";
           
            s1.Start();
            totTimeA.Start();
            Console.WriteLine(wr.getResp(url));
            s1.Stop();
            totTimeA.Stop();
            tA = totTimeA.ElapsedMilliseconds;
            

            int num = 0;
            long t2 = 0;
            var s2 = new Stopwatch(); 
    
            while(num<10){    
                var r = new Random();
                int index = r.Next(items.Count);
                
                url = "http://py1:5000/GroceryShoppingServer/addToCart?clientname=azi&item="+items[index];
                
                s2.Start();
                totTimeA.Start(); 
                Console.WriteLine(wr.getResp(url));
                s2.Stop();
                totTimeA.Stop();
                t2 += s2.ElapsedMilliseconds;
                
                num++;
            }
            tA = totTimeA.ElapsedMilliseconds;
               
               
           

            var s3 = new Stopwatch();
            long t3 = 0;
            s3.Start();
            totTimeA.Start();
            url = "http://py1:5000/GroceryShoppingServer/total?clientname=azi";
            Console.WriteLine("\nTotal: " + wr.getResp(url));
            s3.Stop();
            totTimeA.Stop();
            t3 = s3.ElapsedMilliseconds;
            tA = totTimeA.ElapsedMilliseconds;

            
            
            Console.WriteLine("\n\n------------------------------------------");
            var s4 = new Stopwatch();
            long t4 = 0;
            url = "http://py1:5000/GroceryShoppingServer/receipt?clientname=azi";
            s4.Start();
            totTimeA.Start();
            Console.Write(wr.getResp(url));
            s4.Stop();
            totTimeA.Stop();
            t4 = s4.ElapsedMilliseconds;
            tA = totTimeA.ElapsedMilliseconds;
            
    /////////////////////////////////////////////////////////////////////////////////////////////       
            Console.WriteLine("\n\n\n------------------------------------------");
            Console.WriteLine("Test2: 10 clients, 10 items each ");
            
            var s6 = new Stopwatch();
            var totTimeB = new Stopwatch();
            long tB = 0;
            long t6 = 0;
            
            for(int x = 0; x<10;x++){
                url = "http://py1:5000/GroceryShoppingServer/addClient?clientname=client"+(x+1).ToString();
                s6.Start();
                totTimeB.Start();
                wr.getResp(url);
                s6.Stop();
                totTimeB.Stop();
                
                
            }
            t6 = s6.ElapsedMilliseconds;
                tB = totTimeB.ElapsedMilliseconds;
               Console.WriteLine("Added 10 clients to server");
          
         
            Console.WriteLine("\n\n");
            num = 0;
            var s7 = new Stopwatch();
            long t7 = 0;
            
            while(num<10){    
                var r = new Random();
                int index = r.Next(items.Count);
                for(int x=0;x<10;x++){
                    url = "http://py1:5000/GroceryShoppingServer/addToCart?clientname=client"+(x+1).ToString()+"&item="+items[index];
                    s7.Start();
                    totTimeB.Start();
                    wr.getResp(url);
                    s7.Stop();
                    totTimeB.Stop();
                    
                    
                }
                num++;
            }
            
            t7 = s7.ElapsedMilliseconds;
                    tB = totTimeB.ElapsedMilliseconds;
              Console.WriteLine("Added 10 items to each 10 clients");

            

            var s8 = new Stopwatch();
            long t8=0;
            for(int x=0;x<10;x++){
                url = "http://py1:5000/GroceryShoppingServer/total?clientname=client"+(x+1).ToString();
                s8.Start();
                totTimeB.Start();
                wr.getResp(url);
                s8.Stop();
                totTimeB.Stop();
               
            }
             t8 = s8.ElapsedMilliseconds;
                tB = totTimeB.ElapsedMilliseconds;
            Console.WriteLine("got total for each client");
            
            
            
          //  Console.WriteLine("\n\n------------------------------------------\n\n");
            var s9 = new Stopwatch();
            long t9 = 0;
            for(int x=0;x<10;x++){
                url = "http://py1:5000/GroceryShoppingServer/receipt?clientname=client"+(x+1).ToString();
                s9.Start();
                totTimeB.Start();
                wr.getResp(url);
                s9.Stop();
                totTimeB.Stop();
                
            }
             t9 = s9.ElapsedMilliseconds;
                tB = totTimeB.ElapsedMilliseconds;
             Console.WriteLine("got receipts for each 20 clients");
   

  /////////////////////////////////////////////////////////////////////////////////////////////  

            Console.WriteLine("\n\n\n------------------------------------------");
            Console.WriteLine("Test3: 20 clients, 50 items each");


            var s10 = new Stopwatch();
            var totTimeC = new Stopwatch();
            long t10 = 0;
            long tC = 0;
            
            for(int x = 0; x<20;x++){
                url = "http://py1:5000/GroceryShoppingServer/addClient?clientname=client"+(x+1).ToString();
                 
                s10.Start();
                totTimeC.Start();
                wr.getResp(url);
                s10.Stop();
                totTimeC.Stop();
               
               

            }
            t10 = s10.ElapsedMilliseconds;
                tC = totTimeC.ElapsedMilliseconds;
            
            Console.WriteLine("Added 20 clients to server");
            
            Console.WriteLine("\n\n");
            num = 0;
            var s11 = new Stopwatch();
            long t11 = 0;
            
            while(num<50){    
                var r = new Random();
                int index = r.Next(items.Count);
                for(int x=0;x<20;x++){
                    url = "http://py1:5000/GroceryShoppingServer/addToCart?clientname=client"+(x+1).ToString()+"&item="+items[index];
                    
                    s11.Start();
                    totTimeC.Start();
                    wr.getResp(url);
                     s11.Stop();
                    totTimeC.Stop();
                    
                }
                num++;
            }
            t11 = s11.ElapsedMilliseconds;
                    tC = totTimeC.ElapsedMilliseconds;
           
            Console.WriteLine("Added 50 items to each 20 clients");
            

            var s12 = new Stopwatch();
            long t12 = 0;
            
            for(int x=0;x<20;x++){
                url = "http://py1:5000/GroceryShoppingServer/total?clientname=client"+(x+1).ToString();
                s12.Start();
                totTimeC.Start();
                wr.getResp(url);
                 s12.Stop();
                totTimeC.Stop();
                
                
            }
            t12 = s12.ElapsedMilliseconds;
                tC = totTimeC.ElapsedMilliseconds;
            Console.WriteLine("got total for each client");
            
        //    Console.WriteLine("\n\n------------------------------------------\n\n");
            var s13 = new Stopwatch();
            long t13 = 0;
            
            for(int x=0;x<20;x++){
                url = "http://py1:5000/GroceryShoppingServer/receipt?clientname=client"+(x+1).ToString();
                s13.Start();
                totTimeC.Start();
                wr.getResp(url);
                s13.Stop();
                totTimeC.Stop();
              
            }
              t13 = s13.ElapsedMilliseconds;
                tC = totTimeC.ElapsedMilliseconds;
            Console.WriteLine("got receipts for each 20 clients");


            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Test1: 1 client, 10 items ");
            Console.WriteLine("Time to add client: "+s1.ElapsedMilliseconds);
            Console.WriteLine("\nTime to add 10 items: "+t2);
            Console.WriteLine("\nTime to get Total: "+t3);
            Console.WriteLine("\nTime to Check-Out: "+t4);
            Console.WriteLine("\nTotal Time: "+tA);


            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Test2: 10 clients, 10 items each ");
            Console.WriteLine("\nTime to add 10 clients: "+t6);
            Console.WriteLine("\nTime to add 10 items each: "+t7);
            Console.WriteLine("\nTime to get Total: "+t8);
            Console.WriteLine("\nTime to Check-Out: "+t9);
            Console.WriteLine("\nTotal Time: "+tB);


            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Test3: 20 clients, 50 items each");
            Console.WriteLine("\nTime to add 20 clients: "+t10);
            Console.WriteLine("\nTime to add 50 items each: "+t11);
            Console.WriteLine("\nTime to get Total: "+t12);
            Console.WriteLine("\nTime to Check-Out: "+t13);
            Console.WriteLine("\nTotal Time: "+tC);
            Console.WriteLine("\n------------------------------------------");

        }
    }
}

