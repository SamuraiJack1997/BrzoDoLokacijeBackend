CREATE TABLE IF NOT EXISTS `Comment` (
  `commentId` int NOT NULL AUTO_INCREMENT,
  `userId` int NOT NULL,
  `postId` int NOT NULL,
  `comment` varchar(255) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`commentId`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;


INSERT INTO `comment` (`commentId`, `userId`, `postId`, `comment`) VALUES (NULL, '6', '1', 'Comment Test...');