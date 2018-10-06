


CREATE TABLE Course (
    CourseID   INT PRIMARY KEY IDENTITY  NOT NULL,
    CourseName VARCHAR (50) NOT NULL,
    CourseFees MONEY        NOT NULL,
    Schedule   VARCHAR (20) NOT NULL,
    CourseDuration VARCHAR (20) NOT NULL,
    TrainerID  INT FOREIGN KEY REFERENCES Trainers (TrainerID),
    ExamDetailID  INT FOREIGN KEY REFERENCES ExamDetails (ExamDetailID)	
)
GO

--------------------------------------------------------------------------

INSERT INTO Course VALUES ('C#',12000,'Morning','14 months',1,2)

--------------------------------------------------------------------------

-------------------------------------------
CREATE TABLE Trainers 
(
    TrainerID INT  PRIMARY KEY  IDENTITY  NOT NULL,
    TrainerName  VARCHAR (50) NOT NULL,
    Email     VARCHAR (50) NOT NULL,
    Gender   VARCHAR (15) NOT NULL,
    Mobile    VARCHAR (15) NOT NULL
)
GO

------------------------------------------------------------------------

INSERT INTO Trainers VALUES ('Foysal Wahid','foysal@gmail.com','Male','123654')

------------------------------------------------------------------------

-------------------------------------------

CREATE TABLE Trainees(
    TraineeID INT PRIMARY KEY IDENTITY NOT NULL,
    TraineeName  VARCHAR (50) NOT NULL,
    Email    VARCHAR (50) NOT NULL,
    Gender    VARCHAR (15) NOT NULL,
    Mobile    VARCHAR (15) NOT NULL,
    Address   VARCHAR (80) NOT NULL,
    CourseID  INT FOREIGN KEY REFERENCES Course(CourseID)
)
GO
-------------------------------------------------------------------------------------

INSERT INTO Trainees VALUES ('Fariya','fariya@gmail.com','Female','123654','Chittagong',3)

-------------------------------------------------------------------------------------


-------------------------------------------

CREATE TABLE ExamDetails(
    ExamDetailID INT PRIMARY KEY IDENTITY NOT NULL,
    ExamName  VARCHAR (30) NOT NULL,
    ExamDate  DATETIME NOT NULL,
    ExternalMarks DECIMAL(18,2) NOT NULL,
    EvidenceMarks DECIMAL(18,2) NOT NULL    
)
GO

--------------------------------------------------------------------------

INSERT INTO ExamDetails VALUES ('C#_MT-1',30/03/2018,92,45)

--------------------------------------------------------------------------




