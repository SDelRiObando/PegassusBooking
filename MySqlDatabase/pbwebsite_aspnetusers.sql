-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: pbwebsite
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Discriminator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Zipcode` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Gender` int DEFAULT NULL,
  `SSN` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Street` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `DOB` date DEFAULT NULL,
  `Specialty` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `InsuranceId` int DEFAULT NULL,
  `DepartmentId` int DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  `Role` int DEFAULT NULL,
  `City` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `FirstName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `LastName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `State` int DEFAULT NULL,
  `HospitalId` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`),
  KEY `IX_AspNetUsers_DepartmentId` (`DepartmentId`),
  KEY `IX_AspNetUsers_InsuranceId` (`InsuranceId`),
  KEY `IX_AspNetUsers_HospitalId` (`HospitalId`),
  CONSTRAINT `FK_AspNetUsers_Departments_DepartmentId` FOREIGN KEY (`DepartmentId`) REFERENCES `departments` (`Id`),
  CONSTRAINT `FK_AspNetUsers_Hospitals_HospitalId` FOREIGN KEY (`HospitalId`) REFERENCES `hospitals` (`Id`),
  CONSTRAINT `FK_AspNetUsers_Insurances_InsuranceId` FOREIGN KEY (`InsuranceId`) REFERENCES `insurances` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('143745df-adec-42a0-8451-aa17dc422b62','ApplicationUser','91101',1,NULL,'100 North Garfield Ave','1990-04-03','Pediatrician',NULL,NULL,'andreaescobeda@nomail.com','ANDREAESCOBEDA@NOMAIL.COM','andreaescobeda@nomail.com','ANDREAESCOBEDA@NOMAIL.COM',0,'AQAAAAIAAYagAAAAEI5Fh93NOAG5w1mLrYKEVA4QfMbAHrrUcwMHKsknYidorOLJCaHmWl8eLxKby7DkmA==','JXJZLRERACXLR4UTDRTDV3IVMRS5F5GE','9ba25a6f-4014-4d75-bacd-98b3cefd8395',NULL,0,0,NULL,1,0,1,'Pasadena','Andrea','Escobeda',4,NULL),('4798ad68-893c-4080-bd3c-b0aba888f992','ApplicationUser','91108',0,NULL,'2325 Brentford Road','1983-01-14',NULL,NULL,NULL,'johndoe@ymail.com','JOHNDOE@YMAIL.COM','johndoe@ymail.com','JOHNDOE@YMAIL.COM',0,'AQAAAAIAAYagAAAAEAkXgX2qyXbNPhYO254xVEwxJ47ZxNZO3tTlu3/24VNT+bzk8Ad0Mpf1nt3lxzLrSQ==','SW46L3WVFFJ5XRKWVG37MKMKHJWZTJGE','90bce72c-5753-4f48-bfee-70876b680173',NULL,0,0,NULL,1,0,1,'San Marino','John','Doe',4,2),('747f710f-b77d-4377-aa8a-b636f2d9fcb8','ApplicationUser','80085',0,'123-45-6789','742 Evergreen Terrace','1956-05-12',NULL,NULL,NULL,'homersimpson@simpson.net','HOMERSIMPSON@SIMPSON.NET','homersimpson@simpson.net','HOMERSIMPSON@SIMPSON.NET',0,'AQAAAAIAAYagAAAAEF/+KQDMRc5sb5+LBisnjsA8b5GcWkgwjSroR+TLZyEy7IKogw4vtYaJe1fD36GhXQ==','DNWSBTNR5CGNJW6MFBBXNXU2M6TJVCEK','4cf53b6e-2663-445c-bda4-31bde3f78ca3',NULL,0,0,NULL,1,0,0,'Spring Field','Homer','Simpson',36,NULL),('806b642e-99ef-43f7-ae45-d73a9aeba14b','ApplicationUser','91030',0,NULL,'1653 Amberwood Dr Apt 4','1997-11-23',NULL,NULL,NULL,'vanitasla@gmail.com','VANITASLA@GMAIL.COM','vanitasla@gmail.com','VANITASLA@GMAIL.COM',0,'AQAAAAIAAYagAAAAEDvTgowcu9eL1omtWDTXFz3fBeD8JWg3K1/U+jhMWb5g4+C2ieO9r5VhpRHnX6VDXA==','YZDPNLZN7EMYX25XX3QB3QZ35VM23BA5','de1c90f4-cb3f-4232-8d40-34b9e9894ba1',NULL,0,0,NULL,1,0,2,'South Pasadena','Santiago','Del Rio Obando',4,NULL);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-08  8:54:27
