USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	CONSTRAINT PK_user PRIMARY KEY (user_id),
	email_address varchar(50) NULL,

)

CREATE TABLE properties (
	property_id int IDENTITY(1,1) NOT NULL,
	landlord_id int NOT NULL,
	description varchar(500) NOT NULL,
	address_line_one varchar(50) NOT NULL,
	address_line_two varchar(50) NULL,
	state_abbreviation varchar(2) NOT NULL,
	city varchar(50) NOT NULL,
	zip_code int NOT NULL,
	price money NOT NUll,
	date_available date NOT NULL,
	available bit NOT NULL,
	beds int NOT NULL,
	baths decimal(2,1) NOT NULL,
	CONSTRAINT PK_property_id PRIMARY KEY (property_id),
	CONSTRAINT FK_landlord_id FOREIGN KEY (landlord_id) REFERENCES users (user_id)
)
CREATE TABLE images (
	image_link varchar(1000) NOT NULL,
	property_id int NOT NULL,
	image_id int IDENTITY(1,1) NOT NULL,
	thumbnail bit NOT NULL,
	CONSTRAINT FK_property_id FOREIGN KEY (property_id) REFERENCES properties (property_id),
	CONSTRAINT PK_image_id PRIMARY KEY (image_id) 
)
CREATE TABLE tasks(
	employee_id int  NULL,
	task_id int  IDENTITY (1,1) NOT NULL,
	property_id int NOT NULL,
	is_urgent bit NOT NULL,
	task_description varchar(50) NOT NULL,
	date_entered date DEFAULT(GETDATE()),
	date_scheduled date NULL,
	task_status varchar(50) NOT NULL,
	CONSTRAINT PK_task_id PRIMARY KEY (task_id),
	CONSTRAINT FK_employee_id FOREIGN KEY (employee_id) REFERENCES users (user_id),
	CONSTRAINT FK_property_task FOREIGN KEY (property_id) REFERENCES properties (property_id)
)

CREATE TABLE employees_landlords(
	employee_id INT NOT NULL,
    landlord_id INT NOT NULL,
	CONSTRAINT PK_employee_landlord PRIMARY KEY (employee_id, landlord_id),
    CONSTRAINT FK_employee FOREIGN KEY (employee_id) REFERENCES users (user_id),
    CONSTRAINT FK_landlord FOREIGN KEY (landlord_id) REFERENCES users (user_id)
)

CREATE TABLE renters_properties(
	renter_id INT NOT NULL,
    property_id INT NOT NULL,
	CONSTRAINT PK_renter_property PRIMARY KEY (renter_id, property_id),
    CONSTRAINT FK_renter FOREIGN KEY (renter_id) REFERENCES users (user_id),
    CONSTRAINT FK_property FOREIGN KEY (property_id) REFERENCES properties (property_id)
)

CREATE TABLE applications(
	application_id INT IDENTITY(1,1) NOT NULL,
	renter_id INT NOT NULL,
	landlord_id INT NOT NULL,
	property_id INT NOT NULL,
	name VARCHAR(100) NOT NULL,
	email VARCHAR(100) NOT NULL,
	tenants INT NOT NULL,
	move_in_date date NOT NULL,
	income MONEY NOT NULL,
	status varchar(50) NULL,
	CONSTRAINT PK_app_id PRIMARY KEY (application_id),
	CONSTRAINT FK_renter_id FOREIGN KEY (renter_id) REFERENCES users (user_id),
	CONSTRAINT FK_lanlord_id FOREIGN KEY (landlord_id) REFERENCES users (user_id),
	CONSTRAINT FK_property_app FOREIGN KEY (property_id) REFERENCES properties (property_id),
)


--TODO Photo table links to property id

--populate default data for users (user1,2,3 all have password user)
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('landlord1','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','landlord');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('landlord2','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','landlord');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('landlord3','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','landlord');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('employee1','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','employee');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('employee2','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','employee');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('employee3','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','employee');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('renter1','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','renter');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('renter2','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','renter');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('renter3','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','renter');

--populate default data for properties
INSERT INTO properties (landlord_id, description, address_line_one, address_line_two, state_abbreviation, city, zip_code, price, date_available, available, beds, baths) VALUES (1, 'Located along the city eastern border, the RED is an innovative, upscale community at the crossroads of Oakley, Hyde Park, and Madisonville. With 14 unique styles of studios, one, and two-bedroom apartment homes, and secured parking, the RED is sure to please downtown commuters and Cincinnati newcomers.', '5110 Herringbone Dr', 'Apt E', 'OH', 'Cincinnati', '45227', 700, '08/02/2021', 1, 3, 2.5);
INSERT INTO properties (landlord_id, description, address_line_one, state_abbreviation, city, zip_code, price, date_available, available, beds, baths) VALUES (1, 'Modern. Spacious. Open concept. Granite. Stainless. Pool. Fitness. Theater. Yes, it is all here. Heritage At Oakley Square in Cincinnati, OH offers all-new 1, 2, and 3 bedroom apartments.', '4382 Marburg Ave', 'OH', 'Cincinnati', '45209', 900, '08/10/2022', 0, 2, 1);
INSERT INTO properties (landlord_id, description, address_line_one, state_abbreviation, city, zip_code, price, date_available, available, beds, baths) VALUES (2, 'Welcome to Academy on Fourth, a residential community featuring one and two-bedroom apartments in Newport, KY. Spacious layouts and amenities welcome you home, along with exceptional service and an ideal location within walking distance to shopping, dining and entertainment options.', '101 E 4th St', 'KY', 'Newport', '41071', 1000, '09/19/2021', 0, 2, 2);
INSERT INTO properties (landlord_id, description, address_line_one, state_abbreviation, city, zip_code, price, date_available, available, beds, baths) VALUES (3, 'Nestled in Northern Kentucky in the premier development Manhattan Harbour, The Gateway Flats Boutique Apartments offers spacious lofts with quartz counter tops, energy-efficient stainless steel appliances, barn-style doors and laminate flooring throughout.', '284 Manhattan Blvd', 'KY', 'Dayton', '41074', 2000, '10/02/2021', 1, 5, 3.5);

--populate default data for images
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('1', 'https://i.imgur.com/HiNohRo.jpeg', 1);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('2', 'https://i.imgur.com/fFdmrX4.jpeg', 1);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('2', 'https://i.imgur.com/HiNohRo.jpeg', 0);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('3', 'https://i.imgur.com/fFdmrX4.jpeg', 1);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('3', 'https://i.imgur.com/HiNohRo.jpeg', 0);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('3', 'https://i.imgur.com/HiNohRo.jpeg', 0);
INSERT INTO images (property_id, image_link, thumbnail) VALUES ('4', 'https://i.imgur.com/HiNohRo.jpeg', 1);

--populate default data for tasks
INSERT INTO tasks (property_id, is_urgent, task_description, task_status) VALUES (1, 1, 'Pipes leaking', 'Pending')
INSERT INTO tasks (employee_id, property_id, is_urgent, task_description, date_scheduled, task_status) VALUES (6, 2, 0, 'Infested with Bats', '08/15/2021', 'Scheduled')
INSERT INTO tasks (employee_id, property_id, is_urgent, task_description, date_scheduled, task_status) VALUES (7, 2, 0, 'Random guy living in the closet', '08/4/2021', 'Completed')

--populate default data for employees_landlords
INSERT INTO employees_landlords (employee_id, landlord_id) VALUES (6, 1);
INSERT INTO employees_landlords (employee_id, landlord_id) VALUES (7, 1);
INSERT INTO employees_landlords (employee_id, landlord_id) VALUES (6, 2);
INSERT INTO employees_landlords (employee_id, landlord_id) VALUES (8, 3);

--populate default data for renters_properties
INSERT INTO renters_properties (renter_id, property_id) VALUES (9, 2);
INSERT INTO renters_properties (renter_id, property_id) VALUES (10, 3);

--populate default data for applications
INSERT INTO applications (renter_id, landlord_id, property_id, name, email, tenants, move_in_date, income, status) VALUES (4, 1, 1, 'Jane Doe', 'test@email.com', 2, '08/23/2021', 60000, 'Pending')
INSERT INTO applications (renter_id, landlord_id, property_id, name, email, tenants, move_in_date, income, status) VALUES (4, 1, 2, 'John Doe', 'test@email.com', 2, '08/23/2021', 60000, 'Pending')

GO