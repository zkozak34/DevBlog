-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: mysql:3306
-- Generation Time: May 23, 2022 at 05:04 PM
-- Server version: 8.0.29
-- PHP Version: 8.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `devblog`
--

-- --------------------------------------------------------

--
-- Table structure for table `authors`
--

CREATE TABLE `authors` (
  `Id` int NOT NULL,
  `FullName` varchar(155) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Email` varchar(155) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Password` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ProfileImage` varchar(155) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Overview` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `authors`
--

INSERT INTO `authors` (`Id`, `FullName`, `Email`, `Password`, `ProfileImage`, `Overview`, `CreatedDate`, `UpdatedDate`) VALUES
(6, 'Zeynel KOZAK', 'zeynel.kozak@outlook.com', '871E7BEE4310B946E59E50551E318CA3AABE8D0BE5E1656A03E32292DC87E91D', 'string', 'Full stack Developer', '2022-05-14 00:03:08', '2022-05-13 21:03:07');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `Id` int NOT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `Title` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Path` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`Id`, `CreatedDate`, `UpdatedDate`, `Title`, `Path`) VALUES
(10, '2022-05-14 00:02:17', '2022-05-13 21:02:16', 'VueJS', 'vuejs'),
(11, '2022-05-14 00:02:34', '2022-05-13 21:02:33', '.NET', 'dotnet');

-- --------------------------------------------------------

--
-- Table structure for table `posts`
--

CREATE TABLE `posts` (
  `Id` int NOT NULL,
  `Title` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Content` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Overview` varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ThumbnailImage` mediumtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `AuthorId` int DEFAULT NULL,
  `CategoryId` int DEFAULT NULL,
  `CreatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedDate` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `posts`
--

INSERT INTO `posts` (`Id`, `Title`, `Content`, `Overview`, `ThumbnailImage`, `AuthorId`, `CategoryId`, `CreatedDate`, `UpdatedDate`) VALUES
(58, 'Post Title 1', 'Post Content 1', 'Post Overview 1', '1975587871074297995.png', 6, 10, '2022-05-14 01:49:51', '2022-05-14 01:52:32');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `authors`
--
ALTER TABLE `authors`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `posts`
--
ALTER TABLE `posts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `post_category_fk` (`CategoryId`),
  ADD KEY `post_author_fk` (`AuthorId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `authors`
--
ALTER TABLE `authors`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `posts`
--
ALTER TABLE `posts`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `posts`
--
ALTER TABLE `posts`
  ADD CONSTRAINT `posts_ibfk_1` FOREIGN KEY (`AuthorId`) REFERENCES `authors` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `posts_ibfk_2` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
