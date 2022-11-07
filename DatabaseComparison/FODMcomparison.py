import mysql.connector;

#AWS
#mydb = mysql.connector.connect(host="fodm-ud.cqaozi6qomg6.us-east-1.rds.amazonaws.com",user="admin", passwd="ABCDE12345", database="world")

#GCP
mydb = mysql.connector.connect(host="34.122.149.60",user="root", passwd="", database="world")
mycursor = mydb.cursor()
import timeit

start = timeit.default_timer()



stop = timeit.default_timer()

print('Time: ', stop - start)

#Insert Statements
Country = "Insert into country VALUES ('ZZZ','Newly Created Country','Asia','Southern and Central Asia','652090.00','2022','22720000','45.9','5976.00','793.00','Newbie','Republic','Raja Baksha','245','NB')"

Language = "Insert into countrylanguage (CountryCode, Language, IsOfficial, Percentage) VALUES ('ZZZ', 'Elvy','T',90.1)"
   
City = "INSERT INTO city VALUES(110001, 'Thiem', 'ZZZ' , 'Theoderr', 17800);"

print("records entered to database.")

#Update Statements
update1 = "UPDATE countrylanguage SET Language='AANONE' WHERE CountryCode='ABW' AND Language='Dutch' "

update2 = "UPDATE city SET Name='AACity' WHERE ID='1' "

update3 = "UPDATE country SET Name='AACountry' WHERE Code='ABW'"

print("Both records UPDATED in database.")

#Delete Statements
delete1 = "Delete from countrylanguage WHERE CountryCode='ABW'"

delete2 = "Delete from city WHERE CountryCode='ABW'"

delete3 = "Delete from country WHERE Code='ABW'"

print("Both records are DELETED from database.")

mycursor.execute(Country)
mycursor.execute(City)
mycursor.execute(Language)
mycursor.execute(update1)
mycursor.execute(update2)
mycursor.execute(update3)
mycursor.execute(delete1)
mycursor.execute(delete2)
mycursor.execute(delete3)



stop = timeit.default_timer()

print('Time: ', stop - start) 