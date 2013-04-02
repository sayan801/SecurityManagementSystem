-- MySQL dump 10.13  Distrib 5.5.9, for Win32 (x86)
--
-- Host: localhost    Database: securitydb
-- ------------------------------------------------------
-- Server version	5.5.15

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Current Database: `securitydb`
--

CREATE DATABASE /*!32312 IF NOT EXISTS*/ `securitydb` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `securitydb`;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `contact` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `homenumber` varchar(100) DEFAULT NULL,
  `address` varchar(150) DEFAULT NULL,
  `joiningdate` varchar(100) DEFAULT NULL,
  `employeeType` varchar(45) DEFAULT NULL,
  `remark` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES ('41355.871353044','11','11','11','11','111','2013-03-14 00:00:00','Others','11'),('41366.7520551968','dhrdh','hdfhdfh','dfhfd','hfdhfd','hfdhdfhdf','2013-04-02 00:00:00','Others','fdhfd'),('41366.7528319213','gfhd','fdghfg','hdh','dfh','hdfgh','2013-04-02 00:00:00','Dfh','ghgh'),('41366.7732265278','rhbrh','hreh','rehreh','rehr','brehbre','2013-04-02 18:33:17','ehre','herh'),('41366.7784820486','sdgds','gdgs','dg','dsg','gds','2013-04-02 00:00:00','sdg','sdgs'),('41366.8005881829','Somnath','fdnf','nfdn','gdndg','fbf','2013-04-02 00:00:00','Others','dgng');
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `regvisitor`
--

DROP TABLE IF EXISTS `regvisitor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `regvisitor` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `address` varchar(150) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `idcardno` varchar(45) DEFAULT NULL,
  `visitortype` varchar(45) DEFAULT NULL,
  `purpose` varchar(100) DEFAULT NULL,
  `visitwhom` varchar(45) DEFAULT NULL,
  `signtime` datetime DEFAULT NULL,
  `remark` varchar(150) DEFAULT NULL,
  `timewilltake` varchar(45) DEFAULT NULL,
  `prmsnGrntdby` varchar(45) DEFAULT 'N/A',
  `allowvisitBy` varchar(45) DEFAULT 'N/A',
  `employId` varchar(45) DEFAULT 'N/A',
  `regvisitorcol` varchar(45) DEFAULT 'N/A',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `regvisitor`
--

LOCK TABLES `regvisitor` WRITE;
/*!40000 ALTER TABLE `regvisitor` DISABLE KEYS */;
INSERT INTO `regvisitor` VALUES ('41354.7833968056','fg','fh','fg','fgjfg','Unknown','gjg','fgj','2013-03-15 00:00:00','fgj','fjg','N/A','N/A','N/A','N/A'),('41354.7852696644','segs','sdg','sdgd','sgd','Unknown','dsg','sd','2013-03-05 00:00:00','sdg','sg','N/A','N/A','N/A','N/A'),('41365.7624343287','Partha','Maniktala','9809898987','Ration Card','Unknown','Nothing','Rabin','2013-04-04 00:00:00','Man','30 Min','N/A','N/A','N/A','N/A'),('41365.7775214005','qw','qw','qw','qw','Unknown','wq','qwqw','2013-04-01 00:00:00','wq','wq','N/A','N/A','N/A','N/A'),('41365.7881297801','sad','asd','sad','sad','Unknown','asd','sad','2013-04-01 00:00:00','asd','asd','N/A','N/A','N/A','N/A'),('41366.7370317361','fdnbfdn','ngdngn','dngdg','ndgndgn','Unknown','gdngdn','dgngdngdn','2013-04-02 00:00:00','gdngd','ngdngd','N/A','N/A','N/A','N/A');
/*!40000 ALTER TABLE `regvisitor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `residence`
--

DROP TABLE IF EXISTS `residence`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `residence` (
  `id` varchar(100) NOT NULL,
  `fmlyhadsname` varchar(100) DEFAULT NULL,
  `houseno` varchar(100) DEFAULT NULL,
  `roomno` varchar(100) DEFAULT NULL,
  `contact` varchar(100) DEFAULT NULL,
  `emailaddrs` varchar(100) DEFAULT NULL,
  `fmlymebrs` varchar(200) DEFAULT NULL,
  `visitinghrs` varchar(100) DEFAULT NULL,
  `remark` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `residence`
--

LOCK TABLES `residence` WRITE;
/*!40000 ALTER TABLE `residence` DISABLE KEYS */;
INSERT INTO `residence` VALUES ('41354.8181759606','scs','sas','safssafs','asf','saf','safas','fsfsa','fasa'),('41354.9883948032','ghjfg','fgjf','jfgjgf','jgfj','fgjfgj','fgjfg','jfjfg','jfgfjfg'),('41366.7526112037','fbhdfbhdfhfh','fdhdf','hdfh','dfhdfh','fhdh','fh','fhd','hdhf'),('41366.7683283218','adsa','sad','asd','sad','sad','safs','fs','af'),('41366.7783474769','dsg','dsgsd','gds','gsd','g','dgsd','gdsg','dsg'),('41366.8007785185','kanu','dv','dsvds','vds','vdsvdsv','dsv','dsvd','svds');
/*!40000 ALTER TABLE `residence` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `security`
--

DROP TABLE IF EXISTS `security`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `security` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `address` varchar(145) DEFAULT NULL,
  `contact` varchar(45) DEFAULT NULL,
  `joiningdate` datetime DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `homenumber` varchar(45) DEFAULT NULL,
  `remark` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `security`
--

LOCK TABLES `security` WRITE;
/*!40000 ALTER TABLE `security` DISABLE KEYS */;
INSERT INTO `security` VALUES ('41366.7623595602','anirban','bamangachi','9898989878','2013-04-19 00:00:00','AN2@hajja','033','dssfd'),('41366.7775615509','hrbs','bhdn','dxnfhs','2013-04-02 00:00:00','fsh','fs','sff'),('41366.7785786458','dsg','dsgsg','sg','2013-04-02 00:00:00','sdg','sgds','gsg');
/*!40000 ALTER TABLE `security` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `userid` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `address` varchar(150) DEFAULT NULL,
  `contact` varchar(100) DEFAULT NULL,
  `hints` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workorder`
--

DROP TABLE IF EXISTS `workorder`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `workorder` (
  `id` varchar(100) NOT NULL,
  `orderBy` varchar(145) DEFAULT NULL,
  `workDetails` varchar(545) DEFAULT NULL,
  `assignTo` varchar(145) DEFAULT NULL,
  `orderDate` datetime DEFAULT NULL,
  `status` varchar(45) DEFAULT 'N/A',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workorder`
--

LOCK TABLES `workorder` WRITE;
/*!40000 ALTER TABLE `workorder` DISABLE KEYS */;
INSERT INTO `workorder` VALUES ('41366.8285493866','kanu','xbf','Somnath','2013-04-02 00:00:00','bfd');
/*!40000 ALTER TABLE `workorder` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2013-04-02 20:21:46
