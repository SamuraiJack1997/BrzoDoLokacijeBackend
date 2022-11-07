-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 07, 2022 at 08:48 PM
-- Server version: 5.7.31
-- PHP Version: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `brzodolokacije`
--

-- --------------------------------------------------------

--
-- Table structure for table `likes`
--

DROP TABLE IF EXISTS `likes`;
CREATE TABLE IF NOT EXISTS `likes` (
  `postId` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `date` date NOT NULL,
  KEY `postId` (`postId`),
  KEY `userId` (`userId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `likes`
--

INSERT INTO `likes` (`postId`, `userId`, `date`) VALUES
(1, 6, '0001-01-01'),
(1, 7, '2022-11-02');

-- --------------------------------------------------------

--
-- Table structure for table `photo`
--

DROP TABLE IF EXISTS `photo`;
CREATE TABLE IF NOT EXISTS `photo` (
  `photoId` int(11) NOT NULL,
  `description` varchar(255) NOT NULL,
  `photoLocation` varchar(255) NOT NULL,
  PRIMARY KEY (`photoId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `post`
--

DROP TABLE IF EXISTS `post`;
CREATE TABLE IF NOT EXISTS `post` (
  `postId` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `description` varchar(255) NOT NULL,
  `latitude` double NOT NULL,
  `longitude` double NOT NULL,
  `userId` int(11) NOT NULL,
  `createdDate` date NOT NULL,
  PRIMARY KEY (`postId`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post`
--

INSERT INTO `post` (`postId`, `title`, `description`, `latitude`, `longitude`, `userId`, `createdDate`) VALUES
(1, 'Test Post', 'Test post', 11.2, 12.1, 6, '2022-11-07');

-- --------------------------------------------------------

--
-- Table structure for table `postphotos`
--

DROP TABLE IF EXISTS `postphotos`;
CREATE TABLE IF NOT EXISTS `postphotos` (
  `postId` int(11) NOT NULL,
  `photoId` int(11) NOT NULL,
  PRIMARY KEY (`photoId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `userId` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `surname` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `profilePicId` varchar(255) DEFAULT NULL,
  `password` blob NOT NULL,
  PRIMARY KEY (`userId`),
  UNIQUE KEY `usernameIndex` (`username`),
  UNIQUE KEY `emailIndex` (`email`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `username`, `name`, `surname`, `email`, `profilePicId`, `password`) VALUES
(6, 'test', 'Test3', 'Test3', 'test', 'null', 0x9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08),
(7, 'test3', 'Test3', 'Test3', 'test3', 'null', 0x9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08),
(8, 'test4', 'Test3', 'Test3', 'test4', 'null', 0x9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
