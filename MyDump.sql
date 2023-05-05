-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: volsu
-- ------------------------------------------------------
-- Server version	8.0.28

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
-- Table structure for table `assets`
--

DROP TABLE IF EXISTS `assets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assets` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `type` varchar(45) DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assets`
--

LOCK TABLES `assets` WRITE;
/*!40000 ALTER TABLE `assets` DISABLE KEYS */;
INSERT INTO `assets` VALUES (1,'NVIDIA','stock',3000),(2,'Tesla','stock',9000),(3,'Alphabet','stock',800),(4,'TrexCompany','stock',700),(5,'PayPal','stock',600),(6,'Adobe','stock',500),(7,'Amazon','stock',400),(8,'Hibbett','stock',300),(9,'Under','stock',200),(10,'Scotts','stock',100),(11,'Vanguard','fund',1000),(12,'S&P 500','fund',900),(13,'FXUS','fund',800),(14,'SBSP','fund',700),(15,'iSharesU.S.','fund',600),(16,'Technology','fund',500),(17,'Vanguard','fund',400),(18,'iMOEX','fund',300),(19,'Tinkoff','fund',200),(20,'ETF','fund',100),(21,'Gold','metal',1000),(22,'Silver','metal',900),(23,'Iron','metal',800),(24,'Aluminium','metal',700),(25,'Copper','metal',600),(26,'Steel','metal',500),(27,'Nickel','metal',400),(28,'Tin','metal',300),(29,'Zinc','metal',200),(30,'Platinum','metal',100);
/*!40000 ALTER TABLE `assets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `assets_in_briefcase`
--

DROP TABLE IF EXISTS `assets_in_briefcase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `assets_in_briefcase` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `asset_ID` int DEFAULT NULL,
  `briefcase_ID` int DEFAULT NULL,
  `count` int DEFAULT NULL,
  `price` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `ainb1` (`asset_ID`) /*!80000 INVISIBLE */,
  KEY `FK_ainb2_idx` (`briefcase_ID`),
  CONSTRAINT `FK_ainb1` FOREIGN KEY (`asset_ID`) REFERENCES `assets` (`ID`),
  CONSTRAINT `FK_ainb2` FOREIGN KEY (`briefcase_ID`) REFERENCES `briefcase` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `assets_in_briefcase`
--

LOCK TABLES `assets_in_briefcase` WRITE;
/*!40000 ALTER TABLE `assets_in_briefcase` DISABLE KEYS */;
INSERT INTO `assets_in_briefcase` VALUES (6,1,NULL,43,86000),(7,2,NULL,3,27000),(8,3,NULL,3,2400),(9,6,NULL,3,1500),(10,12,NULL,9,8100),(11,24,NULL,4,2800),(12,9,NULL,3,600),(14,10,NULL,1,100),(15,21,NULL,5,5000),(16,17,NULL,5,2000),(20,7,NULL,5,2000),(21,4,NULL,10,7000);
/*!40000 ALTER TABLE `assets_in_briefcase` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `assets_in_briefcase_AFTER_INSERT` AFTER INSERT ON `assets_in_briefcase` FOR EACH ROW BEGIN
	INSERT INTO history (date_change,cost)VALUE((SELECT CURRENT_DATE()),(SELECT SUM(price) FROM assets_in_briefcase));
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `assets_in_briefcase_AFTER_UPDATE` AFTER UPDATE ON `assets_in_briefcase` FOR EACH ROW BEGIN
	INSERT INTO history (cost) SELECT SUM(price) FROM assets_in_briefcase;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `assets_in_briefcase_AFTER_DELETE` AFTER DELETE ON `assets_in_briefcase` FOR EACH ROW BEGIN
	INSERT INTO history (cost) SELECT SUM(price) FROM assets_in_briefcase;
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `briefcase`
--

DROP TABLE IF EXISTS `briefcase`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `briefcase` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `user_ID` int DEFAULT NULL,
  `full_price` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `bi` (`user_ID`),
  CONSTRAINT `FK_bi` FOREIGN KEY (`user_ID`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `briefcase`
--

LOCK TABLES `briefcase` WRITE;
/*!40000 ALTER TABLE `briefcase` DISABLE KEYS */;
/*!40000 ALTER TABLE `briefcase` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `changes`
--

DROP TABLE IF EXISTS `changes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `changes` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `asset_ID` int NOT NULL,
  `date_change` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `price` float NOT NULL,
  PRIMARY KEY (`ID`),
  KEY `ci` (`asset_ID`),
  CONSTRAINT `FK_ch` FOREIGN KEY (`asset_ID`) REFERENCES `assets` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `changes`
--

LOCK TABLES `changes` WRITE;
/*!40000 ALTER TABLE `changes` DISABLE KEYS */;
INSERT INTO `changes` VALUES (2,1,'2022-04-25 22:39:36',2000);
/*!40000 ALTER TABLE `changes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `history`
--

DROP TABLE IF EXISTS `history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `history` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `briefcase_ID` int DEFAULT NULL,
  `date_change` date DEFAULT NULL,
  `cost` float DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `hi` (`briefcase_ID`),
  CONSTRAINT `FK_hi` FOREIGN KEY (`briefcase_ID`) REFERENCES `briefcase` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `history`
--

LOCK TABLES `history` WRITE;
/*!40000 ALTER TABLE `history` DISABLE KEYS */;
INSERT INTO `history` VALUES (2,NULL,'2022-05-10',74000),(3,NULL,'2022-05-11',74000),(7,NULL,'2022-05-12',80000),(8,NULL,'2022-05-13',80000),(11,NULL,'2022-05-16',100000),(12,NULL,'2022-05-17',150000),(13,NULL,'2022-05-18',80900),(14,NULL,'2022-05-19',90400),(15,NULL,'2022-05-20',89500),(18,NULL,'2022-05-23',107500),(19,NULL,'2022-05-24',150500),(20,NULL,'2022-05-25',228500),(21,NULL,'2022-05-26',140500),(22,NULL,'2022-05-27',148500),(25,NULL,'2022-05-30',135500),(26,NULL,'2022-05-31',137500),(27,NULL,'2022-06-07',144500);
/*!40000 ALTER TABLE `history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `ID` int NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','admin','admin','123'),(2,'admin2','admin','admin1','1234'),(6,NULL,NULL,'user','123'),(7,NULL,'user','user2','123');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'volsu'
--

--
-- Dumping routines for database 'volsu'
--
/*!50003 DROP PROCEDURE IF EXISTS `changes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `changes`(IN a INT, IN b float)
BEGIN
INSERT INTO changes (asset_ID,price) value(a,b);
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `income` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `income`(IN f datetime, IN t datetime)
BEGIN 
	declare a,b,income float default 5;
    set a = (select cost from history where date_change = f);
    set b = (select cost from history where date_change = t);
    set income = b - a; 
    select income;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-07  2:22:36
