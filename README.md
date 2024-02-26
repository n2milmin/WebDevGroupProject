Nicole 

I was in charge of the Search functionality and the Car Rental Database Table
For the Index of each functionality (Flights, Hotels, Car Rentals), there is a search bar and radio buttons to specify the users search
For the Controllers, I have essentially the same code throughout the Index methods for each Flights, Hotels and Car rentals
	There is a searchString and a sortBy variable 
	The searchString is whatever the user wants to find
	The sortBy variable determines what part of the list the user is looking in (Airline or Price or etc)
	The major differences are what the sortBy consists of, which is different for each functionality
For the Home page, I have a search bar and 3 radio buttons for each functionaly
	I attempted to get a page that would search all three functionalities at once, but I couldn't get it to work
	There are error messages that appear when the user doesn't enter or choose something 
 We got a little confused along the way so instead of actually pulling work, I manually put it all together. It was easier when taking the database into consideration.


 Tomer
 
My code takes the primary key from a table passes it through its class controller to a method in the booking class that adds an entry based on the information in the table at that index


 Waisiman
 
Guest booking controller
