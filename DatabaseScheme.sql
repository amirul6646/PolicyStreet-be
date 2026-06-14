CREATE TABLE Employee (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeCode VARCHAR(20) NOT NULL UNIQUE,

    FullName VARCHAR(100) NOT NULL,
    Gender VARCHAR(10) NULL,
    DateOfBirth DATE NULL,

    Email VARCHAR(150) NULL,
    PhoneNumber VARCHAR(20) NULL,

    DepartmentId INT NOT NULL,
    PositionId INT NOT NULL,

    HireDate DATE NOT NULL DEFAULT GETDATE(),
    Salary DECIMAL(18,2) NULL,

    IsActive BIT NOT NULL DEFAULT 1,

    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy INT NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy INT NULL,

    -- Relationships
    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId),

    CONSTRAINT FK_Employee_Position
        FOREIGN KEY (PositionId) REFERENCES Position(PositionId)
);

CREATE TABLE Position (
    PositionId INT IDENTITY(1,1) PRIMARY KEY,
    PositionCode VARCHAR(20) NOT NULL UNIQUE,
    PositionName VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy VARCHAR(100) NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy VARCHAR(100) NULL
);

CREATE TABLE Department (
    DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
    DepartmentCode VARCHAR(20) NOT NULL UNIQUE,
    DepartmentName VARCHAR(100) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    CreatedBy VARCHAR(100) NULL,
    UpdatedAt DATETIME NULL,
    UpdatedBy VARCHAR(100) NULL
);