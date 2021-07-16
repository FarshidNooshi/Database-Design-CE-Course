-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 16, 2021 at 11:04 PM
-- Server version: 10.4.19-MariaDB
-- PHP Version: 8.0.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `proj1_db_aut`
--

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `from_id` varchar(20) NOT NULL,
  `to_id` varchar(20) NOT NULL,
  `text` varchar(128) DEFAULT NULL,
  `ava_id` int(11) DEFAULT NULL,
  `time` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `messages`
--

INSERT INTO `messages` (`from_id`, `to_id`, `text`, `ava_id`, `time`) VALUES
('zeus2', 'zeus3', 'this text is message', NULL, '2021-05-29 21:36:33'),
('zeus2', 'zeus3', 'this text is message', NULL, '2021-05-29 21:36:52'),
('zeus2', 'zeus3', NULL, 9, '2021-05-29 21:37:23'),
('zeus2', 'zeus3', NULL, 10, '2021-05-29 21:37:35'),
('zeus', 'zeus100', NULL, 18, '2021-07-16 20:46:07'),
('zeus', 'zeus100', NULL, 19, '2021-07-16 20:46:50'),
('zeus', 'zeus100', 'test', NULL, '2021-07-16 20:47:09'),
('zeus', 'zeus100', 'testssssss', NULL, '2021-07-16 20:47:26'),
('zeus100', 'zeus', NULL, 20, '2021-07-16 20:57:36');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD KEY `from_id` (`from_id`),
  ADD KEY `to_id` (`to_id`),
  ADD KEY `ava_id` (`ava_id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `messages`
--
ALTER TABLE `messages`
  ADD CONSTRAINT `messages_ibfk_1` FOREIGN KEY (`from_id`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `messages_ibfk_2` FOREIGN KEY (`to_id`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `messages_ibfk_3` FOREIGN KEY (`ava_id`) REFERENCES `ava` (`Ava_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
