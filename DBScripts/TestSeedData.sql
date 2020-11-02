INSERT INTO Vehicles VALUES ('Honda','Accord',0,1996,NULL)
INSERT INTO Vehicles VALUES ('Hyundai','Accent',0,2000,NULL)

INSERT INTO Accessory VALUES('Floor Carpet',45.95,'test description')
INSERT INTO Accessory VALUES('Floor Luxury Carpet',89.95,'test description 2')

--Create a relationship between a car and accessories
--Second parameter represents the ID of vehicle
INSERT INTO VehicleBrandAccessories VALUES (1,1,'NA')
INSERT INTO VehicleBrandAccessories VALUES (1,2,'NA')