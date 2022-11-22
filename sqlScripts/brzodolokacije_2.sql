-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Nov 22, 2022 at 10:56 AM
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
-- Table structure for table `comment`
--

DROP TABLE IF EXISTS `comment`;
CREATE TABLE IF NOT EXISTS `comment` (
  `commentId` int(11) NOT NULL AUTO_INCREMENT,
  `userId` int(11) NOT NULL,
  `postId` int(11) NOT NULL,
  `comment` varchar(255) NOT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`commentId`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `comment`
--

INSERT INTO `comment` (`commentId`, `userId`, `postId`, `comment`, `date`) VALUES
(1, 6, 1, 'Comment Test...', '2022-11-23 18:59:59'),
(2, 7, 1, 'test test', '0001-01-01 00:00:00'),
(3, 7, 1, 'test test', '2022-11-20 20:09:52');

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
(1, 7, '2022-11-02'),
(4, 7, '0001-01-01');

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
  `photo_url` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`postId`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `post`
--

INSERT INTO `post` (`postId`, `title`, `description`, `latitude`, `longitude`, `userId`, `createdDate`, `photo_url`) VALUES
(1, 'Test Post', 'Test post', 11.2, 12.1, 6, '2022-11-07', 'test'),
(4, 'Test Post 44', 'Test post 4', 11.2, 12.1, 6, '2022-11-07', 'test');

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
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`userId`, `username`, `name`, `surname`, `email`, `profilePicId`, `password`) VALUES
(6, 'test', 'Test3', 'Test3', 'test', 'null', 0x9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
