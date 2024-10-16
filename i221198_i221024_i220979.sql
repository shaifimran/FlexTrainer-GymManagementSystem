CREATE DATABASE FlexTrainer;

USE FlexTrainer;

-- Define Admin table
CREATE TABLE Admin (
    adminEmail VARCHAR(100) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Define GymOwner table
CREATE TABLE GymOwner (
    ownerEmail VARCHAR(100) PRIMARY KEY,
    addedBy VARCHAR(100) FOREIGN KEY REFERENCES Admin(AdminEmail),
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL
);

-- Define Trainer table
CREATE TABLE Trainer (
    trainerEmail VARCHAR(100) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    speciality VARCHAR(100),
    experience INT,
    qualification VARCHAR(200)
);


-- Define Meal table
CREATE TABLE Meal (
    mealName VARCHAR(100) PRIMARY KEY,
    allergen VARCHAR(100),
    fibre DECIMAL(5,2),
    fats DECIMAL(5,2),
    carbs DECIMAL(5,2),
    protein DECIMAL(5,2),
    calories INT,
    nutrition AS (fibre + carbs + protein + fats) PERSISTED,
    portionSize VARCHAR(100)
);

-- Define Exercise table
CREATE TABLE Exercise (
    exerciseName VARCHAR(100) PRIMARY KEY,
    targetMuscle VARCHAR(100)
);

-- Define Gym table
CREATE TABLE Gym (
    gymName VARCHAR(100) PRIMARY KEY,
    gymOwner VARCHAR(100),
    adminEmail VARCHAR(100),
    isApproved BIT Default 0,
    location VARCHAR(100),
	membership_fees INT,
    customerSatisfaction INT,
    classAttendanceRate DECIMAL(5,2),
    membershipGrowth INT,
    financialPerformance DECIMAL(10,2),
    FOREIGN KEY (gymOwner) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (adminEmail) REFERENCES Admin(adminEmail)
);
-- Define WorkoutPlan table
CREATE TABLE WorkoutPlan (
    workoutPlanID INT PRIMARY KEY Identity(1,1),
	-- Creater's email
    trainerEmail VARCHAR(100) FOREIGN KEY REFERENCES Trainer(trainerEmail),
    memberEmail VARCHAR(100)  ,
    goal VARCHAR(200),
    schedule VARCHAR(200),
    experienceLevel VARCHAR(100)	
);

-- Define DietPlan table
CREATE TABLE DietPlan (
    dietPlanID INT PRIMARY KEY IDENTITY(1,1),
	-- Creater's email
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100) ,
    purpose VARCHAR(200),
    typeOfDiet VARCHAR(100),  
);


-- Define Member table
CREATE TABLE Member (
    memberEmail VARCHAR(100) PRIMARY KEY,
    addedBy VARCHAR(100),
    trainerEmail VARCHAR(100),
	-- following  diet plan ID
    dietPlanID INT,
	isApproved BIT Default 0,
    currentlyFollowingWorkoutPlanID INT FOREIGN KEY REFERENCES WorkoutPlan(workoutPlanID),
    gymName VARCHAR(100),
    memberName VARCHAR(100) NOT NULL,
    password VARCHAR(100) NOT NULL,
    membershipDuration INT,
    objectives VARCHAR(200),
	signup_date DATETime,
    FOREIGN KEY (addedBy) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (dietPlanID) REFERENCES DietPlan(dietPlanID),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName)
);

ALTER TABLE WorkoutPlan ADD FOREIGN KEY (memberEmail) REFERENCES member(memberEmail);
ALTER TABLE dietPlan ADD FOREIGN KEY (memberEmail) REFERENCES member(memberEmail);
ALTER TABLE dietPlan ADD FOREIGN KEY (trainerEmail) REFERENCES trainer(trainerEmail);

-- Define Workout_Exercises table
CREATE TABLE Workout_Exercises (
    day INT,
    workoutPlanID INT,
    exerciseName VARCHAR(100) FOREIGN KEY REFERENCES Exercise(exerciseName),
    sets INT,
    reps INT,
    PRIMARY KEY (day, workoutPlanID, exerciseName),
    FOREIGN KEY (workoutPlanID) REFERENCES WorkoutPlan(workoutPlanID)
);



-- Define Diet_Meal table
CREATE TABLE Diet_Meal (
    day INT,
    dietPlanID INT,
    mealName VARCHAR(100),
    PRIMARY KEY (day, dietPlanID, mealName),
    FOREIGN KEY (dietPlanID) REFERENCES DietPlan(dietPlanID)
);


CREATE TABLE Gym_CustomerSatisfaction (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	customerSatisfaction INT
);
CREATE TABLE Gym_classAttendance (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	date DATE,
	isPresent BIT
);
CREATE TABLE Gym_Membership (
	gymName VARCHAR(100) PRIMARY KEY,
	memberEmail VARCHAR(100),
	date DATE
);

-- Define TrainerRating table
CREATE TABLE TrainerRating (
    trainerEmail VARCHAR(100),
	memberEmail VARCHAR(100),
    rating INT,
    PRIMARY KEY (trainerEmail, memberEmail),
	FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail)
);

-- Define GymTrainers table
CREATE TABLE GymTrainers (
    gymName VARCHAR(100),
    trainerEmail VARCHAR(100),
    PRIMARY KEY (gymName, trainerEmail),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName),
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail)
);

-- Define Gym_Machines table
CREATE TABLE Gym_Machines (
    gymName VARCHAR(100),
    exerciseName VARCHAR(100),
    machineName VARCHAR(100),
    PRIMARY KEY (gymName, exerciseName, machineName),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName),
	FOREIGN KEY (exerciseName) REFERENCES Exercise(exerciseName)
);

CREATE TABLE Trainer_Verification (
	VerificationID INT IDENTITY(1,1) PRIMARY KEY,
    trainerEmail VARCHAR(100),
	gymName VARCHAR(100) Foreign KEY REFERENCES Gym(gymName),
	isVerified BIT DEFAULT 0,
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
);


CREATE TABLE Member_Verification (
	VerificationID INT IDENTITY(1,1) PRIMARY KEY,
    memberEmail VARCHAR(100),
	gymName VARCHAR(100) Foreign KEY REFERENCES Gym(gymName),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail),
);

-- Define Appointment table
CREATE TABLE Appointment (
	AppointmentID INT PRIMARY KEY IDENTITY(1,1),
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    appointmentDescription VARCHAR(200),
    date DATE,
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail)
);

-- Define Feedback table
CREATE TABLE Feedback (
    trainerEmail VARCHAR(100),
    memberEmail VARCHAR(100),
    feedbackContent TEXT,
    FOREIGN KEY (trainerEmail) REFERENCES Trainer(trainerEmail),
    FOREIGN KEY (memberEmail) REFERENCES Member(memberEmail)
);

-- Define Approval table
CREATE TABLE Approval (
    approvalID INT PRIMARY KEY Identity(1,1),
    gymOwnerEmail VARCHAR(100),
    adminEmail VARCHAR(100),
    gymName VARCHAR(100),
    location VARCHAR(100),
    facilitySpecification TEXT,
    activeMembers INT,
    businessPlan VARCHAR(100),
    FOREIGN KEY (gymOwnerEmail) REFERENCES GymOwner(ownerEmail),
    FOREIGN KEY (adminEmail) REFERENCES Admin(adminEmail),
    FOREIGN KEY (gymName) REFERENCES Gym(gymName)
);

-- Define Audit Trail
create table audit_trail(
audit_id INT identity(1,1) primary key,
auditText varchar(200)
);

--admin insert, delete trigger
create trigger trAdminInsert 
on Admin 
after insert 
as
begin 
	IF @@ROWCOUNT > 0
	begin
		INSERT INTO audit_trail (auditText)
		select 'Admin with email: '+ i.adminEmail + ' and name: ' + i.name + ' is added at ' +CAST( GETDATE() as varchar(20))
		from inserted i
	end
end

create trigger trAdminDel 
on Admin 
after delete
as
begin 
	IF @@ROWCOUNT > 0
	begin
		declare @email varchar(100), @name varchar(100)
		select @email=adminEmail from deleted
		select @name=name from deleted
		insert into audit_trail values('Admin with email: '+ @email + ' and name: ' + @name + ' is deleted at ' +CAST( GETDATE() as varchar(20)))
	end
end


--gym owner insert, delete trigger
create trigger trGymOwnerInsert
on GymOwner
after insert
as 
begin 
	IF @@ROWCOUNT > 0
	begin
		INSERT INTO audit_trail (auditText)
		select 'Gym owner signed up with email: '+ i.ownerEmail + ', with name: ' + i.name + ' at ' + CAST( GETDATE() as varchar(20))
		from inserted i
	end
end

CREATE TRIGGER trGymOwnerUpdate
ON GymOwner
AFTER UPDATE
AS 
BEGIN 
	
	DECLARE @ownerEmail VARCHAR(100), @name VARCHAR(100), @addedBy VARCHAR(100)
	INSERT INTO audit_trail (auditText)
	SELECT 'Gym owner: ' + i.ownerEmail + ', with name: ' + i.name + ' approved by: ' + i.addedBy + ' at ' + CAST(GETDATE() AS VARCHAR(20))
	FROM inserted i;

END


create trigger trGymOwnerDelete
on GymOwner
after delete
as 
begin 
	IF @@ROWCOUNT > 0
	begin
		declare @ownerEmail varchar(100), @name varchar(100)
		select @ownerEmail=ownerEmail from deleted
		select @name=name from deleted
		insert into audit_trail values('Gym owner deleted with email: '+ @ownerEmail + ', with name: ' + @name + ' at ' + CAST( GETDATE() as varchar(20)))
	end
end


--gym insert, update, delete trigger
create trigger trGymInsert
on Gym
after insert
as 
begin 
	IF @@ROWCOUNT > 0
	begin
	INSERT INTO audit_trail (auditText)
	select 'Gym signed up with gym name: '+ i.gymName + ', with gym owner: ' + i.gymOwner + ' at ' + CAST( GETDATE() as varchar(20))
	from inserted i
	end
end

CREATE TRIGGER trGymUpdate
ON Gym
AFTER UPDATE
AS 
BEGIN

	INSERT INTO audit_trail (auditText)
	SELECT 'Gym: ' + i.gymName + ' approved by admin: ' + i.adminEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
	FROM inserted i;
END

create trigger trGymDelete
on Gym
after delete
as 
begin 
	IF @@ROWCOUNT > 0
	begin
		declare @gymName Varchar(100), @gymOwner varchar(100)
		select @gymName=gymName from deleted
		select @gymOwner=gymOwner from deleted
		insert into audit_trail values('Gym deleted with gym name: '+ @gymName + ', with gym owner: ' + @gymOwner + ' at ' + CAST( GETDATE() as varchar(20)))
	end
end

--trainer insert, delete trigger
create trigger trTrainerInsert
on Trainer
after insert
as 
begin 
	IF @@ROWCOUNT > 0
	begin
	INSERT INTO audit_trail (auditText)
	select 'Trainer signed up with email: '+ i.trainerEmail + ', with name: ' + i.name + ' at ' + CAST( GETDATE() as varchar(20))
	from inserted i
	end
end

create trigger trTrainerDelete
on Trainer
after delete
as 
begin 
	IF @@ROWCOUNT > 0
	begin
		declare @trainerEmail varchar(100), @name varchar(100)
		select @trainerEmail=trainerEmail from deleted
		select @name=name from deleted
		insert into audit_trail values('Trainer deleted with email: '+ @trainerEmail + ', with name: ' + @name + ' at ' + CAST( GETDATE() as varchar(20)))
	end
end

--workout plan insert trigger
CREATE TRIGGER trWorkoutPlanInsert
ON WorkoutPlan
AFTER INSERT
AS 
BEGIN	
	IF @@ROWCOUNT > 0
	begin
		INSERT INTO audit_trail (auditText)
		SELECT 
			CASE 
				WHEN i.trainerEmail IS NOT NULL THEN 'Trainer created workout plan with plan ID: ' + CAST(i.workoutplanid AS VARCHAR(10)) + ', and email: ' + i.trainerEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
				ELSE 'Member created workout plan with plan ID: ' + CAST(i.workoutplanid AS VARCHAR(10)) + ', and email: ' + i.memberEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			END
		FROM 
			inserted i;
	end
END

--diet plan insert trigger
CREATE TRIGGER trDietPlanInsert
ON DietPlan
AFTER INSERT
AS 
BEGIN 

	INSERT INTO audit_trail (auditText)
	SELECT 
		CASE 
			WHEN i.trainerEmail IS NOT NULL THEN 'Trainer created diet plan with plan ID: ' + CAST(i.dietPlanID AS VARCHAR(10)) + ', and email: ' + i.trainerEmail + ' for purpose: ' + i.purpose + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			ELSE 'Member created diet plan with plan ID: ' + CAST(i.dietPlanID AS VARCHAR(10)) + ', and email: ' + i.memberEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
		END
	FROM 
		inserted i;
END

--member insert,update, delete trigger
create trigger trMemberInsert
on Member
after insert
as 
begin 
	IF @@ROWCOUNT > 0
	begin
	insert into audit_trail(auditText)
	select 'Member signed up with email: '+ i.memberEmail + ', with name: ' + i.memberName + ', at gym: ' +i.gymName+', at time: '+ CAST( GETDATE() as varchar(20))
	from inserted i
	end
end

CREATE TRIGGER trMemberUpdate
ON Member
AFTER UPDATE
AS 
BEGIN 
	INSERT INTO audit_trail (auditText)
	SELECT 
		CASE 
			WHEN i.trainerEmail IS NOT NULL AND d.trainerEmail IS NULL THEN 'Member with email: ' + i.memberEmail + ' selected trainer with email: ' + i.trainerEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			WHEN i.trainerEmail IS NOT NULL AND d.trainerEmail IS NOT NULL AND i.trainerEmail!=d.trainerEmail THEN 'Member with email: ' + i.memberEmail + ' changed trainer from previous trainer with email: ' + d.trainerEmail + ' to new trainer with email: ' + i.trainerEmail + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			WHEN i.gymName IS NOT NULL AND d.gymName IS NULL THEN 'Member with email: ' + i.memberEmail + ' joined gym: ' + i.gymName + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			WHEN i.gymName IS NOT NULL AND d.trainerEmail IS NOT NULL AND i.trainerEmail!=d.trainerEmail THEN 'Member with email: ' + i.memberEmail + ' changed gym from previous gym: ' + d.gymName + ' to new gym: ' + i.gymName + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			WHEN i.currentlyFollowingWorkoutPlanID IS NOT NULL AND d.currentlyFollowingWorkoutPlanID IS NULL THEN 'Member with email: '+i.memberEmail + ' chose workout plan with id: ' + CAST(i.currentlyFollowingWorkoutPlanID as varchar(10)) + ' at ' +CAST(GETDATE() AS VARCHAR(20))
			WHEN i.currentlyFollowingWorkoutPlanID IS NOT NULL AND d.currentlyFollowingWorkoutPlanID IS NOT NULL AND i.currentlyFollowingWorkoutPlanID!=d.currentlyFollowingWorkoutPlanID THEN 'Member with email: '+i.memberEmail + ' changed  workout plan from planID: ' +CAST(d.currentlyFollowingWorkoutPlanID as varchar(10)) + ' to: ' + CAST(i.currentlyFollowingWorkoutPlanID as varchar(10)) + ' at ' + CAST(GETDATE() AS VARCHAR(20))
			WHEN i.dietPlanID IS NOT NULL AND d.dietPlanID IS NULL THEN 'Member with email: '+i.memberEmail + ' chose diet plan with id: ' + CAST(i.dietPlanID as varchar(10)) + ' at ' +CAST(GETDATE() AS VARCHAR(20))
			WHEN i.dietPlanID IS NOT NULL AND d.dietPlanID IS NOT NULL AND i.dietPlanID!=d.dietPlanID THEN 'Member with email: '+i.memberEmail + ' changed  diet plan from planID: ' +CAST(d.dietPlanID as varchar(10)) + ' to: ' + CAST(i.dietPlanID as varchar(10)) + ' at ' + CAST(GETDATE() AS VARCHAR(20))
		END
	FROM 
		inserted i
	INNER JOIN deleted d ON i.memberEmail = d.memberEmail;
END



create trigger trMemberDelete
on Member
after delete
as 
begin 
	IF @@ROWCOUNT > 0
	begin
		insert into audit_trail(auditText)
		select 'Member deleted with email: '+ d.memberEmail + ', with name: ' + d.membername +' from the gym: '+ d.gymName +' at ' + CAST( GETDATE() as varchar(20))
		from deleted d
	end
end

--gymTrainers insert, delete trigger
create trigger tgTrainerVerificationInsert
on Trainer_Verification
after insert
as begin
	IF @@ROWCOUNT > 0
	begin
		INSERT INTO audit_trail (auditText)
		SELECT 'Trainer with email: ' + i.traineremail + ' joined gym: ' + i.gymName + ' at ' + CAST(GETDATE() AS VARCHAR(20))
		FROM inserted i;
	end
end


create trigger tgTrainerVerificationDelete
on Trainer_Verification
after delete
as begin
	IF @@ROWCOUNT > 0
	begin
		INSERT INTO audit_trail (auditText)
		SELECT 'Trainer with email: ' + d.traineremail + ' left gym: ' + d.gymName + ' at ' + CAST(GETDATE() AS VARCHAR(20))
		FROM deleted d;
	end
end

SELECT * FROM audit_trail order by (audit_id) desc;
SELECt * FROM admin;
SELECt * FROM Approval;
Select * from gym;
select * from GymOwner;
SELECt * FROM Trainer;
SELECT * FROM Trainer_Verification;
SELECT * FROM TrainerRating;
SELECT * FROM GymTrainers;
SELECt * FROM member;
SELECT * FROM WorkoutPlan;
SELECT * FROM Workout_Exercises;
SELECt * FROM DietPlan;

-- Inserting data into admin
INSERT INTO Admin (adminEmail, name, password) VALUES 
('a@email', 'Adeel', 'p1'),
('s@email', 'Shaif', 'p2'),
('w@email', 'Wasay', 'p3');

-- Inserting into trainer
INSERT INTO Trainer (trainerEmail, name, password, speciality, experience, qualification) VALUES
('trainer1@email', 'John Doe', 'password1', 'Yoga', 5, 'Yoga Instructor'),
('trainer2@email', 'Jane Smith', 'password2', 'CrossFit', 3, 'CrossFit Level 2 Trainer'),
('trainer3@email', 'Michael Lee', 'password3', 'Bodybuilding', 7, 'ISSA Certified Personal Trainer'),
('trainer4@email', 'Emily Brown', 'password4', 'Pilates', 4, 'Certified Pilates Instructor'),
('trainer5@email', 'David Johnson', 'password5', 'Martial Arts', 6, 'Black Belt in Taekwondo'),
('trainer6@email', 'Sarah Wilson', 'password6', 'Zumba', 2, 'Zumba Certified Instructor'),
('trainer7@email', 'Matthew Davis', 'password7', 'Weightlifting', 8, 'NASM Certified Personal Trainer'),
('trainer8@email', 'Jennifer Martinez', 'password8', 'HIIT', 5, 'HIIT Instructor Certification'),
('trainer9@email', 'Christopher Anderson', 'password9', 'Functional Training', 4, 'Functional Training Specialist'),
('trainer10@email', 'Amanda Taylor', 'password10', 'Cycling', 3, 'Spinning Instructor Certification'),
('trainer11@email', 'Robert Thomas', 'password11', 'Kickboxing', 6, 'Kickboxing Instructor Certification'),
('trainer12@email', 'Jessica Rodriguez', 'password12', 'Barre', 4, 'Certified Barre Instructor'),
('trainer13@email', 'Daniel Hernandez', 'password13', 'TRX', 5, 'TRX Suspension Training Certification'),
('trainer14@email', 'Ashley Garcia', 'password14', 'Swimming', 7, 'Certified Swimming Instructor'),
('trainer15@email', 'Justin Wilson', 'password15', 'Powerlifting', 4, 'Powerlifting Coach Certification'),
('trainer16@email', 'Elizabeth Martinez', 'password16', 'Dance', 6, 'Dance Teacher Certification'),
('trainer17@email', 'William Brown', 'password17', 'Boxing', 5, 'Boxing Coach Certification'),
('trainer18@email', 'Samantha Lopez', 'password18', 'Pilates', 3, 'Pilates Instructor Training'),
('trainer19@email', 'Jason Scott', 'password19', 'Yoga', 4, 'Yoga Alliance Certification'),
('trainer20@email', 'Nicole Young', 'password20', 'CrossFit', 7, 'CrossFit Level 1 Trainer'),
('trainer21@email', 'Kevin King', 'password21', 'Functional Training', 5, 'Functional Movement Systems Certification'),
('trainer22@email', 'Maria Gonzalez', 'password22', 'Bootcamp', 4, 'Bootcamp Instructor Certification'),
('trainer23@email', 'Olivia Rodriguez', 'password23', 'Kickboxing', 3, 'Kickboxing Fitness Trainer Certification'),
('trainer24@email', 'Benjamin Taylor', 'password24', 'Cycling', 5, 'Indoor Cycling Instructor Certification'),
('trainer25@email', 'Sophia Hernandez', 'password25', 'Pilates', 6, 'Advanced Pilates Certification'),
('trainer26@email', 'Jacob Martinez', 'password26', 'Yoga', 4, 'Yoga Teacher Training'),
('trainer27@email', 'Emily Thompson', 'password27', 'HIIT', 3, 'HIIT Instructor Certification'),
('trainer28@email', 'Ethan Davis', 'password28', 'Strength Training', 5, 'Certified Strength and Conditioning Specialist'),
('trainer29@email', 'Mia Garcia', 'password29', 'Dance', 6, 'Certified Dance Instructor'),
('trainer30@email', 'Logan Wilson', 'password30', 'Functional Training', 4, 'Functional Fitness Coach Certification');

-- Inserting into Gym Owner
INSERT INTO GymOwner (ownerEmail, addedBy, name, password) VALUES
('owner1@email.com', 'w@email', 'John Doe', 'password1'),
('owner2@email.com', 'a@email', 'Jane Smith', 'password2'),
('owner3@email.com', 's@email', 'Michael Lee', 'password3'),
('owner4@email.com', 'w@email', 'Emily Brown', 'password4'),
('owner5@email.com', 'a@email', 'David Johnson', 'password5'),
('owner6@email.com', 's@email', 'Sarah Wilson', 'password6'),
('owner7@email.com', 'w@email', 'Matthew Davis', 'password7'),
('owner8@email.com', 'a@email', 'Jennifer Martinez', 'password8'),
('owner9@email.com', 's@email', 'Christopher Anderson', 'password9'),
('owner10@email.com', 'w@email', 'Amanda Taylor', 'password10'),
('owner11@email.com', 'a@email', 'Robert Thomas', 'password11'),
('owner12@email.com', 's@email', 'Jessica Rodriguez', 'password12'),
('owner13@email.com', 'w@email', 'Daniel Hernandez', 'password13'),
('owner14@email.com', 'a@email', 'Ashley Garcia', 'password14'),
('owner15@email.com', 's@email', 'Justin Wilson', 'password15'),
('owner16@email.com', 'w@email', 'Elizabeth Martinez', 'password16'),
('owner17@email.com', 'a@email', 'William Brown', 'password17'),
('owner18@email.com', 's@email', 'Samantha Lopez', 'password18'),
('owner19@email.com', 'w@email', 'Jason Scott', 'password19'),
('owner20@email.com', 'a@email', 'Nicole Young', 'password20'),
('owner21@email.com', 's@email', 'Kevin King', 'password21'),
('owner22@email.com', 'w@email', 'Maria Gonzalez', 'password22');

-- Inserting into Gym
INSERT INTO Gym (gymName, gymOwner, adminEmail, isApproved, location, membership_fees, customerSatisfaction, classAttendanceRate, membershipGrowth, financialPerformance) VALUES
('Gym1', 'owner1@email.com', 'w@email', 1, 'City Center', 100, 85, 90.5, 20, 5000),
('Gym2', 'owner2@email.com', 's@email', 1, 'Downtown', 120, 88, 92.3, 15, 6000),
('Gym3', 'owner3@email.com', 'a@email', 1, 'Westside', 90, 82, 88.7, 25, 4800),
('Gym4', 'owner4@email.com', 'w@email', 1, 'Uptown', 110, 90, 94.2, 18, 5500),
('Gym5', 'owner5@email.com', 's@email', 1, 'Eastside', 95, 86, 91, 22, 5200),
('Gym6', 'owner6@email.com', 'a@email', 1, 'Midtown', 105, 87, 90.8, 21, 5300),
('Gym7', 'owner7@email.com', 'w@email', 1, 'Southside', 100, 89, 93.5, 17, 5900),
('Gym8', 'owner8@email.com', 's@email', 1, 'Northside', 115, 91, 95, 16, 6100),
('Gym9', 'owner9@email.com', 'a@email', 1, 'Suburbia', 80, 80, 85.2, 30, 4700),
('Gym10', 'owner10@email.com', 'w@email', 1, 'Riverside', 125, 92, 96.5, 14, 6200),
('Gym11', 'owner11@email.com', 's@email', 1, 'Hillside', 130, 94, 97.2, 12, 6300),
('Gym12', 'owner12@email.com', 'a@email', 1, 'Beachfront', 95, 85, 89.8, 23, 5400),
('Gym13', 'owner13@email.com', 'w@email', 1, 'Lakeside', 85, 83, 87.5, 28, 4900),
('Gym14', 'owner14@email.com', 's@email', 1, 'Mountainside', 105, 88, 91.7, 19, 5600),
('Gym15', 'owner15@email.com', 'a@email', 1, 'Countryside', 120, 90, 93.8, 16, 6000),
('Gym16', 'owner16@email.com', 'w@email', 1, 'Parkside', 110, 86, 90.1, 20, 5100),
('Gym17', 'owner17@email.com', 's@email', 1, 'Oceanfront', 100, 84, 88.2, 24, 5500),
('Gym18', 'owner18@email.com', 'a@email', 1, 'Riverside', 95, 82, 86.9, 26, 5000),
('Gym19', 'owner19@email.com', 'w@email', 1, 'Hillcrest', 105, 87, 90, 21, 5200),
('Gym20', 'owner20@email.com', 's@email', 1, 'Lakeshore', 115, 91, 94.5, 18, 5700);

-- Inserting into Exercise
INSERT INTO Exercise (exerciseName, targetMuscle)
VALUES
  ('Push-ups', 'Chest'),
  ('Squats', 'Quads'),
  ('Lunges', 'Quads'),
  ('Deadlifts', 'Hamstrings'),
  ('Overhead Press', 'Shoulders'),
  ('Barbell Rows', 'Back'),
  ('Pull-ups', 'Back'),
  ('Dips', 'Triceps'),
  ('Bicep Curls', 'Biceps'),
  ('Tricep Extensions', 'Triceps'),
  ('Plank', 'Core'),
  ('Crunches', 'Abs'),
  ('Side Plank', 'Obliques'),
  ('Walking', 'Cardio'),  -- Cardio doesn't target specific muscles
  ('Running', 'Cardio'),  -- Cardio doesn't target specific muscles
  ('Swimming', 'Cardio'),  -- Cardio doesn't target specific muscles
  ('Cycling', 'Cardio'),  -- Cardio doesn't target specific muscles
  ('Jumping Jacks', 'Cardio'), -- Cardio doesn't target specific muscles
  ('Burpees', 'Full Body');

-- Inserting into GymMachines
INSERT INTO Gym_Machines (gymName, exerciseName, machineName) VALUES
('Gym1', 'Barbell Rows', 'Rowing Machine'),
('Gym1', 'Bicep Curls', 'Cable Machine'),
('Gym1', 'Burpees', 'Plyo Box'),
('Gym2', 'Crunches', 'Ab Roller'),
('Gym2', 'Cycling', 'Stationary Bike'),
('Gym2', 'Deadlifts', 'Smith Machine'),
('Gym3', 'Dips', 'Dip Station'),
('Gym3', 'Jumping Jacks', 'Cardio Equipment'),
('Gym3', 'Lunges', 'Dumbbell Rack'),
('Gym4', 'Overhead Press', 'Barbell Rack'),
('Gym4', 'Plank', 'Exercise Mat'),
('Gym4', 'Pull-ups', 'Pull-up Bar'),
('Gym5', 'Push-ups', 'Push-up Handles'),
('Gym5', 'Running', 'Treadmill'),
('Gym5', 'Side Plank', 'Exercise Ball'),
('Gym6', 'Squats', 'Squat Rack'),
('Gym6', 'Swimming', 'Pool Lane'),
('Gym6', 'Tricep Extensions', 'Cable Machine'),
('Gym7', 'Walking', 'Treadmill'),
('Gym7', 'Tricep Extensions', 'Cable Machine'),
('Gym7', 'Plank', 'Exercise Mat'),
('Gym8', 'Lunges', 'Dumbbell Rack'),
('Gym8', 'Cycling', 'Stationary Bike');

-- Inserting into workout plan
INSERT INTO WorkoutPlan (trainerEmail, memberEmail, goal, schedule, experienceLevel) VALUES
('trainer1@email', NULL, 'Weight Loss', 'Mon-Wed-Fri 8:00 AM', 'Beginner'),
('trainer2@email', NULL, 'Muscle Gain', 'Tue-Thu-Sat 9:00 AM', 'Intermediate'),
('trainer3@email', NULL, 'Endurance Training', 'Mon-Fri 7:00 AM', 'Advanced'),
('trainer4@email', NULL, 'Flexibility Improvement', 'Wed-Sat 10:00 AM', 'Intermediate'),
('trainer5@email', NULL, 'Strength Building', 'Tue-Thu 6:00 PM', 'Advanced'),
('trainer6@email', NULL, 'Cardio Training', 'Mon-Wed-Fri 6:30 AM', 'Intermediate'),
('trainer7@email', NULL, 'HIIT Workout', 'Tue-Thu 5:00 PM', 'Beginner'),
('trainer8@email', NULL, 'Functional Training', 'Wed-Fri-Sun 8:00 AM', 'Advanced'),
('trainer9@email', NULL, 'Powerlifting Routine', 'Mon-Wed-Fri 4:00 PM', 'Intermediate'),
('trainer10@email', NULL, 'Cycling Intervals', 'Tue-Thu-Sat 7:30 AM', 'Beginner'),
('trainer11@email', NULL, 'Kickboxing Workout', 'Mon-Wed-Fri 6:00 PM', 'Advanced'),
('trainer12@email', NULL, 'Barre Fitness', 'Tue-Thu 9:30 AM', 'Intermediate'),
('trainer13@email', NULL, 'TRX Suspension Training', 'Wed-Fri-Sun 10:30 AM', 'Beginner'),
('trainer14@email', NULL, 'Swimming Techniques', 'Mon-Wed-Fri 7:00 AM', 'Intermediate'),
('trainer15@email', NULL, 'Plyometric Exercises', 'Tue-Thu-Sat 5:30 PM', 'Advanced'),
('trainer16@email', NULL, 'Latin Dance Workouts', 'Mon-Wed 6:00 PM', 'Intermediate'),
('trainer17@email', NULL, 'Boxing Drills', 'Tue-Thu 7:00 AM', 'Beginner'),
('trainer18@email', NULL, 'Pilates Core Strengthening', 'Mon-Fri 10:00 AM', 'Advanced'),
('trainer19@email', NULL, 'Yoga Flow', 'Tue-Thu 8:00 AM', 'Intermediate'),
('trainer20@email', NULL, 'CrossFit Circuit', 'Mon-Wed-Fri 5:30 PM', 'Advanced'),
('trainer21@email', NULL, 'Functional Movement', 'Tue-Thu 6:30 AM', 'Beginner'),
('trainer22@email', NULL, 'Bootcamp Challenges', 'Wed-Fri-Sun 6:00 AM', 'Intermediate'),
('trainer23@email', NULL, 'Kickboxing Fitness', 'Mon-Wed 7:00 PM', 'Advanced'),
('trainer24@email', NULL, 'Indoor Cycling Class', 'Tue-Thu-Sat 7:00 AM', 'Intermediate'),
('trainer25@email', NULL, 'Advanced Pilates', 'Mon-Wed-Fri 9:00 AM', 'Advanced'),
('trainer26@email', NULL, 'Yoga Flow', 'Tue-Thu 8:30 AM', 'Beginner'),
('trainer27@email', NULL, 'HIIT Circuit Training', 'Mon-Wed-Fri 6:00 PM', 'Intermediate'),
('trainer28@email', NULL, 'Strength and Conditioning', 'Tue-Thu-Sat 4:00 PM', 'Advanced'),
('trainer29@email', NULL, 'Dance Fitness', 'Wed-Fri 7:30 PM', 'Beginner'),
('trainer30@email', NULL, 'Functional Fitness', 'Mon-Wed-Fri 8:30 AM', 'Intermediate'),
('trainer1@email', NULL, 'Weight Loss', 'Sat-Sun 9:00 AM', 'Intermediate'),
('trainer2@email', NULL, 'Muscle Gain', 'Wed-Fri 10:00 AM', 'Beginner'),
('trainer3@email', NULL, 'Endurance Training', 'Tue-Thu 7:00 PM', 'Advanced'),
('trainer4@email', NULL, 'Flexibility Improvement', 'Mon-Wed-Fri 9:00 AM', 'Intermediate'),
('trainer5@email', NULL, 'Strength Building', 'Thu-Sat 6:00 PM', 'Advanced');

-- Insert into workout_exercises
INSERT INTO Workout_Exercises (day, workoutPlanID, exerciseName, sets, reps) VALUES
(1, 1, 'Lunges', 4, 15),
(3, 1, 'Squats', 4, 12),
(2, 2, 'Deadlifts', 3, 10),
(4, 2, 'Overhead Press', 3, 12),
(6, 2, 'Pull-ups', 4, 8),
(4, 4, 'Crunches', 3, 20),
(6, 4, 'Plank', 3, 45),
(3, 5, 'Bicep Curls', 3, 12),
(4, 5, 'Tricep Extensions', 3, 12),
(6, 5, 'Push-ups', 3, 15),
(2, 10, 'Burpees', 3, 15),
(4, 10, 'Jumping Jacks', 3, 30),
(6, 10, 'Side Plank', 3, 30),
(1, 11, 'Squats', 4, 12),
(2, 12, 'Barbell Rows', 3, 12),
(4, 12, 'Deadlifts', 3, 10),
(6, 12, 'Push-ups', 3, 15),
(1, 15, 'Squats', 4, 12),
(3, 15, 'Deadlifts', 3, 10),
(5, 15, 'Pull-ups', 4, 8),
(2, 20, 'Burpees', 3, 15),
(4, 20, 'Jumping Jacks', 3, 30),
(6, 20, 'Side Plank', 3, 30),
(1, 21, 'Lunges', 4, 15),
(3, 21, 'Squats', 4, 12),
(4, 22, 'Deadlifts', 3, 10),
(6, 22, 'Overhead Press', 3, 12),
(1, 23, 'Pull-ups', 4, 8),
(2, 23, 'Squats', 4, 12),
(4, 25, 'Deadlifts', 3, 10);

-- Inserting into Meal
INSERT INTO Meal (mealName, allergen, fibre, fats, carbs, protein, calories, portionSize) VALUES
('Chicken Stir-Fry', 'Gluten, Soy', 3.5, 12.8, 18.9, 25.6, 320, '1 plate'),
('Greek Salad', 'Dairy', 5.2, 10.1, 15.3, 12.4, 280, '1 bowl'),
('Spaghetti Bolognese', 'Gluten, Dairy', 4.8, 14.5, 25.7, 22.1, 380, '1 plate'),
('Veggie Wrap', 'Gluten', 6.3, 8.7, 20.5, 18.2, 310, '1 wrap'),
('Grilled Salmon', 'Fish', 2.1, 15.9, 7.3, 28.4, 290, '1 fillet'),
('Quinoa Salad', 'None', 8.9, 9.6, 33.4, 11.8, 250, '1 bowl'),
('Tofu Stir-Fry', 'Soy', 4.7, 11.2, 21.8, 16.5, 280, '1 plate'),
('Oatmeal', 'Gluten', 4, 5.2, 25.1, 7.8, 220, '1 bowl'),
('Chicken Caesar Salad', 'Dairy', 3.6, 14, 10.8, 20.5, 290, '1 bowl'),
('Beef Burrito', 'Gluten, Dairy', 6.7, 17.2, 29.5, 24.3, 410, '1 burrito'),
('Lentil Soup', 'None', 9.2, 3.4, 28.6, 12.1, 240, '1 bowl'),
('Eggplant Parmesan', 'Dairy', 5.8, 18.3, 22.6, 13.7, 360, '1 serving'),
('Beef Stir-Fry', 'Soy', 3.9, 13.6, 17.8, 26.2, 330, '1 plate'),
('Spinach Salad', 'None', 6.5, 8.9, 12.4, 10.3, 210, '1 bowl'),
('Baked Chicken', 'None', 2.8, 6.9, 1.5, 30.2, 250, '1 piece'),
('Veggie Burger', 'Gluten, Soy', 5.4, 10.7, 27.9, 14.8, 320, '1 burger'),
('Shrimp Pasta', 'Gluten, Shellfish', 3.2, 11.9, 30.5, 20.4, 370, '1 plate'),
('Caesar Wrap', 'Dairy', 4.1, 12.5, 22.7, 18.3, 320, '1 wrap'),
('Quiche', 'Dairy, Gluten', 2.9, 16.3, 17.6, 14.8, 350, '1 slice'),
('Grilled Tofu', 'None', 3.6, 10.5, 6.8, 22.1, 270, '1 serving'),
('Salmon Salad', 'Fish', 4.5, 15.2, 8.7, 27.6, 320, '1 salad'),
('Avocado Toast', 'Gluten', 5.7, 10, 17.2, 8.9, 260, '1 slice'),
('Turkey Sandwich', 'Gluten', 3.8, 7.4, 22.1, 15.6, 310, '1 sandwich'),
('Bean Chili', 'None', 6.1, 5.5, 22.8, 14.3, 280, '1 bowl'),
('Tuna Salad', 'Fish', 4.2, 13.8, 6.9, 23.1, 300, '1 salad');

-- Inserting into gym trainers

-- Inserting into Member
INSERT INTO Member (memberEmail, addedBy, trainerEmail, dietPlanID, isApproved, currentlyFollowingWorkoutPlanID, gymName, memberName, password, membershipDuration, objectives, signup_date) VALUES
('member1@email.com', 'owner1@email.com', 'trainer1@email', NULL, NULL, NULL, 'Gym1', 'Member 1', 'password', 12, 'Lose weight', '2023-05-19'),
('member2@email.com', 'owner1@email.com', 'trainer2@email', NULL, NULL, NULL, 'Gym1', 'Member 2', 'password', 6, 'Build muscle', '2023-11-24'),
('member3@email.com', 'owner1@email.com', 'trainer3@email', NULL, NULL, NULL, 'Gym1', 'Member 3', 'password', 9, 'Increase stamina', '2024-02-24'),
('member4@email.com', 'owner1@email.com', 'trainer4@email', NULL, NULL, NULL, 'Gym1', 'Member 4', 'password', 12, 'Tone up', '2023-04-14'),
('member5@email.com', 'owner2@email.com', 'trainer5@email', NULL, NULL, NULL, 'Gym2', 'Member 5', 'password', 6, 'Improve flexibility', '2024-01-25'),
('member6@email.com', 'owner2@email.com', 'trainer6@email', NULL, NULL, NULL, 'Gym2', 'Member 6', 'password', 9, 'Gain strength', '2024-02-29'),
('member7@email.com', 'owner2@email.com', 'trainer7@email', NULL, NULL, NULL, 'Gym2', 'Member 7', 'password', 12, 'Cardiovascular health', '2023-03-14'),
('member8@email.com', 'owner2@email.com', 'trainer8@email', NULL, NULL, NULL, 'Gym2', 'Member 8', 'password', 6, 'Increase endurance', '2023-03-30'),
('member9@email.com', 'owner3@email.com', 'trainer9@email', NULL, NULL, NULL, 'Gym3', 'Member 9', 'password', 9, 'Build muscle mass', '2023-11-22'),
('member10@email.com', 'owner3@email.com', 'trainer10@email', NULL, NULL, NULL, 'Gym3', 'Member 10', 'password', 12, 'Lose weight', '2023-11-05'),
('member11@email.com', 'owner3@email.com', 'trainer11@email', NULL, NULL, NULL, 'Gym3', 'Member 11', 'password', 6, 'Increase stamina', '2023-04-17'),
('member12@email.com', 'owner3@email.com', 'trainer12@email', NULL, NULL, NULL, 'Gym3', 'Member 12', 'password', 9, 'Tone up', '2023-05-03'),
('member13@email.com', 'owner4@email.com', 'trainer13@email', NULL, NULL, NULL, 'Gym4', 'Member 13', 'password', 12, 'Improve flexibility', '2023-03-20'),
('member14@email.com', 'owner4@email.com', 'trainer14@email', NULL, NULL, NULL, 'Gym4', 'Member 14', 'password', 6, 'Gain strength', '2023-02-28'),
('member15@email.com', 'owner4@email.com', 'trainer15@email', NULL, NULL, NULL, 'Gym4', 'Member 15', 'password', 9, 'Increase endurance', '2023-01-13'),
('member16@email.com', 'owner4@email.com', 'trainer16@email', NULL, NULL, NULL, 'Gym4', 'Member 16', 'password', 12, 'Build muscle mass', '2023-04-14'),
('member17@email.com', 'owner5@email.com', 'trainer17@email', NULL, NULL, NULL, 'Gym5', 'Member 17', 'password', 6, 'Cardiovascular health', '2023-02-19'),
('member18@email.com', 'owner5@email.com', 'trainer18@email', NULL, NULL, NULL, 'Gym5', 'Member 18', 'password', 9, 'Lose weight', '2023-05-16'),
('member19@email.com', 'owner6@email.com', 'trainer19@email', NULL, NULL, NULL, 'Gym6', 'Member 19', 'password', 12, 'Increase stamina', '2023-09-29'),
('member20@email.com', 'owner6@email.com', 'trainer20@email', NULL, NULL, NULL, 'Gym6', 'Member 20', 'password', 6, 'Tone up', '2023-07-25');

update member set isApproved = 1;

-- Inserting into diet plan
INSERT INTO DietPlan (trainerEmail, memberEmail, purpose, typeOfDiet) VALUES
(NULL, 'member1@email.com', 'Weight Loss', 'Keto'),
('trainer2@email', NULL, 'Muscle Gain', 'Vegan'),
(NULL, 'member3@email.com', 'Endurance Training', 'Paleo'),
('trainer4@email', NULL, 'Flexibility Improvement', 'Mediterranean'),
(NULL, 'member5@email.com', 'Strength Building', 'Low Carb'),
('trainer6@email', NULL, 'Cardio Training', 'Atkins'),
(NULL, 'member7@email.com', 'HIIT Workout', 'Intermittent Fasting'),
('trainer8@email', NULL, 'Functional Training', 'Whole30'),
(NULL, 'member9@email.com', 'Powerlifting Routine', 'Vegetarian'),
('trainer10@email', NULL, 'Cycling Intervals', 'Mediterranean'),
(NULL, 'member11@email.com', 'Kickboxing Workout', 'Keto'),
('trainer12@email', NULL, 'Barre Fitness', 'Vegan'),
(NULL, 'member13@email.com', 'TRX Suspension Training', 'Paleo'),
('trainer14@email', NULL, 'Swimming Techniques', 'Low Carb'),
(NULL, 'member15@email.com', 'Plyometric Exercises', 'Atkins'),
('trainer16@email', NULL, 'Latin Dance Workouts', 'Intermittent Fasting'),
(NULL, 'member17@email.com', 'Boxing Drills', 'Whole30'),
('trainer18@email', NULL, 'Pilates Core Strengthening', 'Vegetarian'),
(NULL, 'member19@email.com', 'Yoga Flow', 'Mediterranean'),
('trainer20@email', NULL, 'CrossFit Circuit', 'Keto'),
(NULL, 'member20@email.com', 'Functional Movement', 'Vegan'),
('trainer22@email', NULL, 'Bootcamp Challenges', 'Paleo'),
(NULL, 'member1@email.com', 'Kickboxing Fitness', 'Low Carb'),
('trainer24@email', NULL, 'Indoor Cycling Class', 'Atkins'),
(NULL, 'member2@email.com', 'Advanced Pilates', 'Intermittent Fasting');


-- Inserting data into diet_meal
INSERT INTO Diet_Meal (day, dietPlanID, mealName) VALUES
(1, 22, 'Chicken Stir-Fry'),
(2, 23, 'Greek Salad'),
(3, 24, 'Spaghetti Bolognese'),
(4, 25, 'Veggie Wrap'),
(5, 26, 'Grilled Salmon'),
(6, 27, 'Quinoa Salad'),
(7, 28, 'Tofu Stir-Fry'),
(8, 29, 'Oatmeal'),
(9, 30, 'Chicken Caesar Salad'),
(10, 31, 'Beef Burrito'),
(11, 32, 'Lentil Soup'),
(12, 33, 'Eggplant Parmesan'),
(13, 34, 'Beef Stir-Fry'),
(14, 35, 'Spinach Salad'),
(15, 36, 'Baked Chicken'),
(16, 37, 'Veggie Burger'),
(17, 38, 'Shrimp Pasta'),
(18, 39, 'Caesar Wrap'),
(19, 40, 'Quiche'),
(20, 41, 'Grilled Tofu'),
(21, 42, 'Salmon Salad'),
(22, 43, 'Avocado Toast'),
(23, 44, 'Turkey Sandwich');

SELECT * FROM Trainer_Verification
delete from Trainer_Verification
-- Inserting into gym trainers
INSERT INTO Trainer_Verification(gymName, trainerEmail, isVerified) VALUES
('Gym1', 'trainer1@email',1),
('Gym1', 'trainer2@email',1),
('Gym1', 'trainer3@email',1),
('Gym1', 'trainer4@email',1),
('Gym2', 'trainer5@email',1),
('Gym2', 'trainer6@email',1),
('Gym2', 'trainer7@email',1),
('Gym2', 'trainer8@email',1),
('Gym3', 'trainer9@email',1),
('Gym3', 'trainer10@email',1),
('Gym3', 'trainer11@email',1),
('Gym3', 'trainer12@email',1),
('Gym4', 'trainer13@email',1),
('Gym4', 'trainer14@email',1),
('Gym4', 'trainer15@email',1),
('Gym4', 'trainer16@email',1),
('Gym5', 'trainer17@email',1),
('Gym5', 'trainer18@email',1),
('Gym6', 'trainer19@email',1),
('Gym6', 'trainer20@email',1),
('Gym11', 'trainer21@email',1),
('Gym11', 'trainer22@email',1),
('Gym12', 'trainer23@email',1),
('Gym12', 'trainer24@email',1),
('Gym13', 'trainer25@email',1),
('Gym13', 'trainer26@email',1),
('Gym14', 'trainer27@email',1),
('Gym14', 'trainer28@email',1),
('Gym15', 'trainer29@email',1),
('Gym15', 'trainer30@email',1),
('Gym16', 'trainer1@email',1),
('Gym16', 'trainer2@email',1),
('Gym17', 'trainer3@email',1),
('Gym17', 'trainer4@email',1),
('Gym18', 'trainer5@email',1),
('Gym18', 'trainer6@email',1),
('Gym19', 'trainer7@email',1),
('Gym19', 'trainer8@email',1),
('Gym20', 'trainer9@email',1),
('Gym20', 'trainer10@email',1);

