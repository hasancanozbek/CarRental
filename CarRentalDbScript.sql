-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema car_rental_db
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema car_rental_db
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `car_rental_db` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `car_rental_db` ;

-- -----------------------------------------------------
-- Table `car_rental_db`.`__efmigrationshistory`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`__efmigrationshistory` (
  `MigrationId` VARCHAR(150) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  `ProductVersion` VARCHAR(32) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NOT NULL,
  PRIMARY KEY (`MigrationId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `car_rental_db`.`brands`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`brands` (
  `Id`  NOT NULL,
  `BrandName` VARCHAR(45) NOT NULL,
  `IsDeleted`  NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Name_UNIQUE` (`BrandName` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 38
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`colours`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`colours` (
  `Id`  NOT NULL,
  `ColourName` VARCHAR(45) NOT NULL,
  `IsDeleted`  NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Colour_UNIQUE` (`ColourName` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`fueltypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`fueltypes` (
  `Id`  NOT NULL,
  `Fuel` VARCHAR(45) NOT NULL,
  `IsDeleted`  NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Fuel_UNIQUE` (`Fuel` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`geartypes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`geartypes` (
  `Id`  NOT NULL,
  `Gear` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `IsDeleted`  NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Gear_UNIQUE` (`Gear` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`cars`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`cars` (
  `Id`  NOT NULL,
  `BrandId`  NOT NULL,
  `GearTypeId`  NOT NULL,
  `FuelTypeId`  NOT NULL,
  `ColourId`  NOT NULL,
  `Model` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `ModelYear`  NOT NULL,
  `Description` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `Price` (10,0) NOT NULL,
  `Active`  NOT NULL DEFAULT '0',
  `Deleted`  NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  INDEX `fk_Cars_Brands_idx` (`BrandId` ASC) VISIBLE,
  INDEX `fk_Cars_GearTypes1_idx` (`GearTypeId` ASC) VISIBLE,
  INDEX `fk_Cars_FuelTypes1_idx` (`FuelTypeId` ASC) VISIBLE,
  INDEX `fk_Cars_Colours1_idx` (`ColourId` ASC) VISIBLE,
  CONSTRAINT `fk_Cars_Brands`
    FOREIGN KEY (`BrandId`)
    REFERENCES `car_rental_db`.`brands` (`Id`),
  CONSTRAINT `fk_Cars_Colours1`
    FOREIGN KEY (`ColourId`)
    REFERENCES `car_rental_db`.`colours` (`Id`),
  CONSTRAINT `fk_Cars_FuelTypes1`
    FOREIGN KEY (`FuelTypeId`)
    REFERENCES `car_rental_db`.`fueltypes` (`Id`),
  CONSTRAINT `fk_Cars_GearTypes1`
    FOREIGN KEY (`GearTypeId`)
    REFERENCES `car_rental_db`.`geartypes` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 8
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`customers`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`customers` (
  `Id`  NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `FirstName` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `LastName` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `NationalId` VARCHAR(11) NOT NULL,
  `Telephone` VARCHAR(10) NOT NULL,
  `Address` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  `PasswordHash` BLOB NOT NULL,
  `PasswordSalt` BLOB NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
  UNIQUE INDEX `Telephone_UNIQUE` (`Telephone` ASC) VISIBLE,
  UNIQUE INDEX `NationalId_UNIQUE` (`NationalId` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`employees`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`employees` (
  `Id`  NOT NULL,
  `Email` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `FirstName` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `LastName` VARCHAR(45) CHARACTER SET 'utf8mb3' NOT NULL,
  `Telephone` VARCHAR(10) NOT NULL,
  `Department` VARCHAR(45) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE,
  UNIQUE INDEX `Telephone_UNIQUE` (`Telephone` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`operationclaims`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`operationclaims` (
  `Id`  NOT NULL,
  `Name` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Name_UNIQUE` (`Name` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `car_rental_db`.`rentdetails`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`rentdetails` (
  `Id`  NOT NULL,
  `CustomerId`  NOT NULL,
  `CarId`  NOT NULL,
  `Price` (10,0) NOT NULL,
  `RentalDate`  NOT NULL,
  `ReturnDate`  NULL DEFAULT NULL,
  `OriginAddress` VARCHAR(255) CHARACTER SET 'utf8mb3' NOT NULL,
  `ReturnAddress` VARCHAR(255) CHARACTER SET 'utf8mb3' NULL DEFAULT NULL,
  PRIMARY KEY (`Id`, `CustomerId`, `CarId`),
  INDEX `fk_RentDetails_Cars1_idx` (`CarId` ASC) VISIBLE,
  INDEX `fk_RentDetails_Customers1_idx` (`CustomerId` ASC) VISIBLE,
  CONSTRAINT `fk_RentDetails_Cars1`
    FOREIGN KEY (`CarId`)
    REFERENCES `car_rental_db`.`cars` (`Id`),
  CONSTRAINT `fk_RentDetails_Customers1`
    FOREIGN KEY (`CustomerId`)
    REFERENCES `car_rental_db`.`customers` (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `car_rental_db`.`useroperationclaims`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `car_rental_db`.`useroperationclaims` (
  `Id`  NOT NULL,
  `UserId`  NOT NULL,
  `OperationClaimId`  NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
