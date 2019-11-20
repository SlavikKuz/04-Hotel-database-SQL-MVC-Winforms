## Hi!

This is a Web App for a hypothetical small hotel where I can test some ideas in ASP.Net Core. 

Keywords: C#, SQL, ASP.net Core, MVC, VS2019, SSMS18, Azure 

## 1. Database and entities design

Rules:
- Client entity, may have many bookings, GuidId
- Booking entity, tied up to the client, may have more than one room, invited guests list (client entities), invoice, GuidId
- Room entity, tied up to the booking, always have room price, GuidId
- RoomPrice entity, tied up to the room. Contains different prices for day/holiday.  GuidId
- Invoice entity, tied up to the booking. Calculates total price for room/list booked rooms according the price on the day. GuidId
- Guest entity, tied to the booking. Guest is Client.
- Holiday entity, simple list of holidays to lookup in. GuidId.  



Database must store information about client, booking, dates, and available rooms. It is possible to store also some additional informanion as comments, or notes for clients' special needs or requests.

<img src="/Readme/DBdiagram.PNG?raw=true" width="640"/>

### dbo.CIient
```sql
id (PK, int, not null)
client_full_name (varchar(50), not null)
email (varchar(50), not null)
tel (varchar(50), not null)
address (varchar(50), not null)
notes (text, not null) //any kind of additional information
```

### dbo.Order
```sql
id (PK, int, not null)
client_id (FK, int, not null)
order_date (datetime, not null)
day_from (FK, date, not null)
day_till (FK, date, not null)
kids (int, not null)
status (varchar(50), not null)
info (text, not null)
```
### dbo.Calendar
```sql
day (PK, date, not null)
weekend (bit, not null) //for pricing policy
holiday (bit, not null) //for pricing policy
```
### dbo.Room
```sql
id (PK, int, not null)
room (varchar(50), not null) //room number with letters
beds (int, not null) //places in the room
floor (varchar(50), not null) //incuding attic, basement, etc
info (text, not null)
step (int, not null) // int, equal to id, for ORDER BY purpose if any change in room number happens
```
### dbo.HotelPlan
```sql
room_id (PK, FK, int, not null) //ocupied room
order_id (PK, FK, int, not null) //ocupied after order
calendar_day (PK, FK, date, not null) //ocupied till
status (varchar(50), not null) //ocupied, paid, reserved, etc
adults (int, not null)
kids (int, not null) //for group orders after single resevation, placement info
```

## 2. `HotelDB` Project Library

### 2.1. Models

#### Client.cs 

```c
//work with clients
public int id { get; private set; }
public string client_full_name { get; private set; }
public string email { get; private set; }
public string tel { get; private set; }
public string address { get; private set; }
public string notes { get; private set; }
```

#### Room.cs 

```c//room description
public long id { get; private set; }
public string room { get; private set; }
public int beds { get; private set; }
public string floor { get; private set; }
public int step { get; private set; }
public string info  { get; private set; }
```

#### Calendar.cs

```c
//schedule for bookings, calendar
public DateTime day { get; private set; }
public DateTime weekend;//autofill
public DateTime holiday;//autofill
```

#### Book.cs

```c
//reservation
public long id { get; private set; }
public long client_id { get; private set; }
public DateTime order_date { get; private set; }
public DateTime day_from { get; private set; }
public DateTime day_till { get; private set; }
public int adults { get; private set; }
public int kids { get; private set; }
public string status { get; private set; }
public string info { get; private set; }
```

#### Plan.cs

```c
//rooms and positions, reservatons
long room_id;
long order_id;
DateTime calendar_day;
public string status { get; private set; }
public int adults { get; private set; }
public int kids { get; private set; }
```


## 3.  of database (from MVC). 
NB! No client's data is planned to be deleted from a database.

Tasks (with sample SQL queries):

```c
ModelClient.InsertClient()
// register a new client
	INSERT INTO Client 
	VALUES ( 0, 
		'Slavik Kuz', 
		'mymail@email.com', 
		'123445678', 
		'Follumsvei 11B, Nordfjord, 9611', 
		'loyal client, traveling with a bike');
```

```c
ModelClient.SelectClients()
// get a list of clients;
	SELECT * FROM Client;
```

```c
ModelClient.SelectClient(string fing)
// get a list of clients (filter);
	SELECT * FROM Client 
	WHERE client_full_name LIKE '%k%'
		OR email   LIKE '%k%'
		OR tel     LIKE '%k%'
		OR address LIKE '%k%'
		OR notes   LIKE '%k%'
		OR id = 'g';
```
```c
ModelClient.SelectClient(int client_id)
// get data for selected client;
	SELECT client_full_name, email, tel, address, notes 
	FROM Client
	WHERE id = '5';
```
```c
ModelClient.UpdateClient(int client_id)
// change client's data;
	UPDATE Client
	SET client_full_name = 'John Doe', 
		email = 'newmail@smthmail.com',
		tel = '987654321',
		address = 'Trænevegen 32, Sørfjord, 3215',
		notes = 'test'
	WHERE id = 1
	LIMIT 1; //control safety
```
```c
ModelCalendar.InsertDays(int year)
// create a calendar for selected year;
	INSERT INTO Calendar
	SET day = '2019-01-01',
	weekend = 1,
	holiday = 0;
```

```c
ModelCalendar.SetHolidays(string day) 
ModelCalendar.OffHolidays(string day) 
// mark some days as holiday/days off;
	UPDATE Calender
	SET holiday = 1
	WHERE day = '2019-01-01';
```

```c
ModelRoom.SelectRoom()
// get a list of rooms;
	SELECT * FROM Room
	ORDER BY step; 
```
```c
ModelRoom.InsertRoom()
// add a new room;
	INSERT INTO Room
	SET room = 'Twin 105',
		beds = 2,
		floor = 1,
		info = 'Sweet twin for a couple';
	UPDATE Room
	SET step = 2
	WHERE id = 2;
```
```c
ModelRoom.SelectRoom(int room_id)
// get info on selected room;
	SELECT * FROM Room
	WHERE id = 1;
```

```c
ModelRoom.UpdateRoom(int room_id)
// change data for selected room;
	UPDATE Room
	SET room = 'Single 105',
		beds = 1,
		floor = 1,
		info = 'Nice single'
	WHERE id = 2;
```
```c
ModelBook.InsertBook()
// add a new registration;
	INSERT INTO Order
	SET client_id = 1,  
		order_date = NOW(),
		day_from = '2016-01-01',
		day_till = '2016-01-01',
		adults = 1,
		kids = 0,
		status = 'paid',
		info = 'test of the field';
```
```c
ModelBook.UpdateStatus (int book_id, string status)
// change registarion's status (canceled, confirmed, waiting confirmation);
	UPDATE Order
	SET status = 'confirmed'
	WHERE id = 1;
```

```c
ModelBook.UpdateBook(int book_id)
// edit registration;
	UPDATE Order
	SET adults = 1,
	kids = 1,
	info = 'not specified'
	WHERE id = 1;
```

```c
ModelBook.UpdateFromDay (int book_id, string day_from)
ModelBook.UpdateTillDay (int book_id, string day_till)
// edit registration period;
	UPDATE Order
	SET day_from = '2016-01-02',
	    day_till = '2016-01-02',
	WHERE id = 1;
```

```c
ModelBook.SelectBooks()
// get a list of registrations;
	SELECT client_id, 
		client, 
		order_date, 
		day_from, 
		day_till, 
		adults, 
		kids, 
		status, 
		o.info 
	FROM Order o
	LEFT JOIN Client c
	ON o.client_id = c.id
	WHERE o.id = 1;
```

```c
ModelBook.SelectBooks(string find)
// get a list of registrations (filter);
	SELECT client_id, 
		client, 
		order_date, 
		day_from, 
		day_till, 
		adults, 
		kids, 
		status, 
		o.info 
	FROM Order o
	LEFT JOIN Client c
	ON o.client_id = c.id
	WHERE client LIKE '%g%'
	OR order_date LIKE 'g%'
	OR day_from LIKE 'g%'
	OR day_till LIKE 'g%'
	OR adults = 'g'
	OR kids = 'g'
	OR status = 'g'
	OR o.info LIKE '%g%';
```

```c
ModelPlan.SelectPlan(string day_from, string day_till)
// get a list of booked rooms on a selected month;
	SELECT room_id, order_id, calendar_day, status, adults, kids
	FROM HotelPlan
	WHERE calendar_day BETWEEN '2019-05-01' AND '2019-05-31';
```

```c
ModelPlan.InsertPlan()
// add a reservation to HotelPlan;
	INSERT INTO HotelPlan
	set room_id = 1,
		order_id = 1,
		calendar_day = '2019-05-20', 
		status = 'confirmed', 
		adults = 1, 
		kids = 1;
```

```c
ModelPlan.ModelPlan(int room_id, init book_id, string calendar_day)
ModelPlan.UpdatePlan()
// change/delete this reservation;
	UPDATE HotelPlan
	SET status = 'cancelled',
		adults = 1,
		kids = 0,
	WHERE room_id = 1,
		book_id=1,
		calendar_day = '2019-05-20';
```

```c
ModelPlan.DeletePlan()
// delete this reservation;
	DELETE FROM HotelPlan
	WHERE room_id = 1,
		book_id=1,
		calendar_day = '2019-05-20';
```

```c
ModelRoom.SelectFreeRooms()
// get a list og empty rooms on selected date;
	SELECT * FROM room
	WHERE id NOT IN 
		(SELECT room_id 
		FROM HotelPlan 
		WHERE calendar_day = '2019-05-20');
```




## 5. Controllers and Views
in the development;