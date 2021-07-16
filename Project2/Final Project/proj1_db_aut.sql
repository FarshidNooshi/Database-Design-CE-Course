-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 16, 2021 at 09:10 PM
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

DELIMITER $$
--
-- Procedures
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddOppinion` (IN `attributes` VARCHAR(256), IN `ava_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    INSERT INTO ava(ava.sender_user, ava.Attributes, ava.Ava_id)
    SELECT username as sender_user, attributes as Attributes, COUNT(DISTINCT ava.Ava_id) + 1 as Ava_id
    FROM ava, blocks
    WHERE NOT(ava.Ava_id = ava_id AND blocks.blocked_id = username AND ava.sender_user = blocks.blocker_id);

    INSERT INTO opinion(opinion.from_id, opinion.to_id)
    SELECT COUNT(DISTINCT ava.Ava_id) as from_id, ava_id as to_id
    FROM ava, blocks
    WHERE NOT(ava.Ava_id = ava_id AND blocks.blocked_id = username AND ava.sender_user = blocks.blocker_id);

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `AddSpecialSignToAva` (IN `ava_id` INT(11), IN `special_sign_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    INSERT INTO ava_specialsigns(ava_specialsigns.ava_id, ava_specialsigns.ava_sender_user,ava_specialsigns.special_sign_id)
    SELECT ava_id as ava_id, username as ava_sender_user, special_sign_id as special_sign_id
    FROM ava as A
    WHERE ava_id = A.Ava_id AND username = A.sender_user;
    
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `add_hashtag_of_ava` (IN `sign` CHAR(6), IN `avaID` INT(11), IN `user_id` VARCHAR(20), IN `time` TIMESTAMP)  BEGIN
	INSERT INTO special_sign(special_sign.sign)
    VALUES(sign);
    
    INSERT INTO ava_specialsigns(ava_id, ava_sender_user, special_sign_id, attached_time)
    SELECT avaID as ava_id, user_id as ava_sender_user, id, time as attached_time
    FROM special_sign
    WHERE special_sign.sign = sign;
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `blockSomeone` (IN `blocked_user` VARCHAR(20))  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
	INSERT INTO blocks(blocker_id, blocked_id)
	SELECT username as blocker_id, blocked_user as blocked_id
    WHERE username NOT IN (SELECT blocks.blocked_id
                           FROM blocks
                           WHERE blocks.blocker_id = blocked_user);
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `create_account` (IN `first_name` VARCHAR(20), IN `second_name` VARCHAR(20), IN `user_name` VARCHAR(20), IN `birth_date` TIMESTAMP, IN `password` VARCHAR(128), IN `Bio` VARCHAR(64))  BEGIN
	INSERT INTO account (first_name, second_name, user_name, birth_date, password, Bio)
	VALUES(first_name, second_name, user_name, birth_date, password(password), Bio);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `followingSomeone` (IN `following_user` VARCHAR(20))  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    INSERT INTO connections
	VALUES (username, following_user);
	
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetAvasWithSpecialSign` (IN `special_sign_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT ava.Ava_id, ava.Attributes, ava.sender_user, ava.time
    FROM ava, ava_specialsigns as special_signs
    WHERE special_signs.special_sign_id = special_sign_id AND special_signs.ava_id = ava.Ava_id 
    										AND username NOT IN(SELECT blocked_id                    			                                                      				     	 FROM blocks
           	    										        WHERE blocker_id = ava.sender_user)
    ORDER BY ava.time DESC;
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMessagesFromSpecialUser` (IN `from_id` VARCHAR(20))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT messages.from_id, messages.text, messages.ava_id, ava.Attributes, messages.time
    FROM messages NATURAL LEFT OUTER JOIN ava
    WHERE messages.to_id = username AND messages.from_id = from_id AND (NOT(text is NULL) 
                                                                   OR (from_id NOT IN (SELECT blocks.blocked_id
     															 					   FROM blocks
     																				   WHERE blocks.blocker_id = username)))
    ORDER BY messages.time DESC;
                                    
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `GetOpinionsOfAAva` (IN `ava_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    SELECT DISTINCT ava.sender_user, ava.time, ava.Attributes, ava.Ava_id
    FROM ava, opinion
    WHERE username NOT IN(SELECT blocked_id
                          FROM blocks
                          WHERE blocker_id = ava.sender_user) AND ((ava.Ava_id = ava_id) OR 
                          (opinion.to_id = ava_id AND opinion.from_id = ava.Ava_id 
                           					 	  AND ava.sender_user NOT IN(SELECT blocker_id
                                                                             FROM blocks
                                                                             WHERE blocked_id = username)));

end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `get_avas_of_someone` ()  BEGIN 

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    SELECT ava.sender_user, ava.time, ava.Attributes
    FROM ava
    WHERE ava.sender_user = username AND username NOT IN (SELECT blocked_id
                                                             FROM blocks
                                                             WHERE blocker_id = username);
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `Get_List_Of_Senders` (IN `name_of_user` VARCHAR(20))  BEGIN 
	
    DECLARE name_of_last_user varchar(20);
    SET name_of_last_user = get_Last_Logged_In_User();
    IF name_of_last_user = name_of_user THEN

        SELECT messages.from_id, MAX(messages.time) as time
        FROM messages
        WHERE messages.to_id = name_of_user AND messages.to_id NOT IN (SELECT blocks.blocked_id
                                                                 FROM blocks
                                                                 WHERE blocks.blocker_id = messages.from_id)
        GROUP BY messages.from_id
        ORDER BY messages.time DESC;
        
    END IF;

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `likeAva` (IN `ava_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    INSERT INTO likes(likes.liker_user_name, likes.liked_ava_id)
    SELECT username as liker_user_name, ava_id as liked_ava_id
    FROM ava
    WHERE 1 = ava.Ava_id AND username NOT IN(SELECT blocks.blocked_id
	                                        FROM blocks
    	                                   	WHERE blocks.blocker_id = ava.sender_user);
                                        
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `log_in` (IN `username` VARCHAR(20), IN `password` VARCHAR(128), OUT `result` VARCHAR(20))  BEGIN 

    INSERT INTO user_logs (user_logs.username)
    SELECT username as user_name 
    FROM account 
    WHERE account.user_name = username AND account.password = PASSWORD(password);
    
    SELECT username as user_name 
    INTO result
    FROM account 
    WHERE account.user_name = username AND account.password = PASSWORD(password);
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `log_out` (IN `username` VARCHAR(20), IN `password` VARCHAR(128))  BEGIN 

    INSERT INTO user_logs (user_logs.username, user_logs.Type)
    SELECT username as user_name, "logout" as Type
    FROM account 
	WHERE account.user_name = username AND account.password = PASSWORD(password);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SendMessageWithAva` (IN `attributes` VARCHAR(256), IN `to_id` VARCHAR(20))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    INSERT INTO ava(ava.sender_user, ava.Attributes, ava.Ava_id)
    SELECT username as sender_user, attributes as Attributes, COUNT(DISTINCT Ava_id) + 1 as Ava_id
    FROM ava
    WHERE username NOT IN (SELECT blocks.blocked_id
                           FROM blocks
                           WHERE blocks.blocker_id = to_id);


    insert INTO messages(messages.from_id, messages.to_id, messages.ava_id)
    SELECT username as from_id, to_id as to_id, COUNT(DISTINCT Ava_id) as ava_id 
    FROM ava
    WHERE username NOT IN(SELECT blocks.blocked_id
                          FROM blocks
                          WHERE blocks.blocker_id = to_id);
                                    
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `SendMessageWithText` (IN `text` VARCHAR(128), IN `to_id` VARCHAR(20))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    insert INTO messages(messages.from_id, messages.to_id, messages.text)
    SELECT DISTINCT username as from_id, to_id as to_id, text as text
    FROM ava
    WHERE username NOT IN(SELECT blocks.blocked_id
                         FROM blocks
                         WHERE blocks.blocker_id = to_id);
                                    
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `send_ava` (IN `attributes` VARCHAR(256))  BEGIN 

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
        INSERT INTO ava(ava.sender_user, ava.Attributes)
        SELECT username as sender_user, attributes as Attributes
        from account
		WHERE account.user_name = username;
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `showAvasFromFollowings` ()  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT ava.Attributes, ava.time, ava.sender_user
    FROM ava, connections C
    where c.follower_user = username AND 
          ava.sender_user = c.following_user AND 
          username NOT IN (SELECT blocked_id
                                   FROM blocks
                                   WHERE blocker_id = c.following_user) 
     ORDER BY ava.time DESC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `showAvasFromSpecificUser` (IN `specific_user` VARCHAR(20))  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT ava.Attributes, ava.time, ava.sender_user
    FROM ava
    where ava.sender_user = specific_user AND username NOT IN (SELECT blocked_id
                                                               FROM blocks
                                                               WHERE blocker_id = specific_user);

END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `showLikersOfAnAva` (IN `ava_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT likes.like_time, likes.liker_user_name as user_name
    FROM likes
    WHERE likes.liked_ava_id = ava_id AND username NOT IN (SELECT blocks.blocked_id
                                                           FROM blocks
                                                           WHERE blocks.blocker_id = likes.liker_user_name)
	ORDER BY likes.like_time DESC;


                                        
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `ShowNumberOfLikes` (IN `ava_id` INT(11))  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    SELECT COUNT(*) AS count_of_likes
    FROM ava, likes
    WHERE ava.Ava_id = likes.liked_ava_id AND ava.Ava_id = ava_id 
                                          AND username NOT IN (SELECT blocks.blocked_id
                                                               FROM blocks
	                                                           WHERE blocks.blocker_id = ava.sender_user);
                                        
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `showPopularAvas` ()  BEGIN

	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    SELECT COUNT(likes.liked_ava_id) as count_of_likes, ava.Ava_id, ava.sender_user, ava.time, ava.Attributes
    FROM likes, ava
    WHERE ava.Ava_id = likes.liked_ava_id 
          AND username NOT IN (SELECT blocks.blocked_id
                               FROM blocks
                               WHERE blocks.blocker_id = ava.sender_user)  
    GROUP BY ava.Ava_id
    ORDER BY count_of_likes DESC;
                                        
end$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `show_logs` ()  BEGIN 
	DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
        SELECT *
        FROM user_logs
        where user_logs.username = username
        ORDER BY user_logs.log_time DESC;
    
    
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `unblockSomeone` (IN `blocked_user` VARCHAR(20))  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    DELETE FROM blocks
	WHERE blocked_id = blocked_user AND blocker_id = username;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `unfollowingSomeone` (IN `following_user` VARCHAR(20))  BEGIN
	
    DECLARE username varchar(20);
    SET username = get_Last_Logged_In_User();
    
    DELETE FROM connections
	WHERE connections.follower_user = username AND connections.following_user = following_user;

END$$

--
-- Functions
--
CREATE DEFINER=`root`@`localhost` FUNCTION `get_Last_Logged_In_User` () RETURNS VARCHAR(20) CHARSET utf8mb4 BEGIN 
	
    DECLARE name_of_user varchar(20);
    set name_of_user =	(select username
                         FROM user_logs
                         WHERE log_time = (SELECT MAX(log_time)
                                           FROM user_logs
                                           WHERE Type = 'log_in'));
   	RETURN (name_of_user);
    
end$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `first_name` varchar(20) NOT NULL,
  `second_name` varchar(20) NOT NULL,
  `user_name` varchar(20) NOT NULL,
  `birth_date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `registration_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `password` varchar(128) NOT NULL,
  `Bio` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`first_name`, `second_name`, `user_name`, `birth_date`, `registration_date`, `password`, `Bio`) VALUES
('farshid', 'nooshi', 'zeus', '2007-12-31 20:30:01', '2021-05-28 11:02:29', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam'),
('farshid', 'nooshi', 'zeus10', '2007-12-31 20:30:01', '2021-05-28 11:02:30', '*A1EE80F62AFE6DB5C78DEED6A6FCDEF4FF8C3B96', 'salam'),
('farshid', 'nooshi', 'zeus100', '2007-12-31 20:30:01', '2021-07-14 16:07:34', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam'),
('farshid', 'nooshi', 'zeus2', '2007-12-31 20:30:01', '2021-05-28 11:02:29', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam'),
('farshid', 'nooshi', 'zeus3', '2007-12-31 20:30:01', '2021-05-28 11:02:30', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam'),
('farshid', 'nooshi', 'zeus4', '2007-12-31 20:30:01', '2021-05-28 11:02:30', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam'),
('farshid', 'nooshi', 'zeus5', '2007-12-31 20:30:01', '2021-05-28 11:02:30', '*E56A114692FE0DE073F9A1DD68A00EEB9703F3F1', 'salam');

--
-- Triggers `account`
--
DELIMITER $$
CREATE TRIGGER `update_stats` AFTER INSERT ON `account` FOR EACH ROW INSERT INTO account_stats(id, registration_time)
VALUES(new.user_name, new.registration_date)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account_stats`
--

CREATE TABLE `account_stats` (
  `id` varchar(20) NOT NULL,
  `registration_time` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `account_stats`
--

INSERT INTO `account_stats` (`id`, `registration_time`) VALUES
('zeus100', '2021-07-13 19:30:00'),
('zeus101', '2021-07-16 16:04:19'),
('zz', '2021-07-16 17:08:39'),
('test1', '2021-07-16 17:11:40'),
('asd', '2021-07-16 17:12:36'),
('asdfsadf', '2021-07-16 17:13:02'),
('sadfasdf', '2021-07-16 17:13:36');

-- --------------------------------------------------------

--
-- Table structure for table `ava`
--

CREATE TABLE `ava` (
  `sender_user` varchar(20) NOT NULL,
  `time` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Attributes` varchar(256) NOT NULL,
  `Ava_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ava`
--

INSERT INTO `ava` (`sender_user`, `time`, `Attributes`, `Ava_id`) VALUES
('zeus', '2021-05-28 11:58:05', 'test test', 1),
('zeus2', '2021-05-28 11:58:44', 'test test2', 2),
('zeus3', '2021-05-28 11:58:44', 'test test3', 3),
('zeus', '2021-05-28 11:58:44', 'test test4', 4),
('zeus', '2021-05-28 16:17:17', 'tik tok', 5),
('zeus', '2021-05-28 16:17:50', 'tik tok', 6),
('zeus3', '2021-05-28 16:31:28', 'tik tok', 7),
('zeus2', '2021-05-29 21:34:08', 'this is for message', 8),
('zeus2', '2021-05-29 21:37:23', 'this is for message', 9),
('zeus2', '2021-05-29 21:37:35', 'this is for message', 10),
('zeus', '2021-07-16 19:08:55', 'nazar', 17),
('zeus3', '2021-07-09 20:34:19', 'test procedure', 48),
('zeus100', '2021-07-14 16:18:04', 'test test trigger', 49),
('zeus100', '2021-07-14 18:22:08', 'test test #abcdt #1adsf #asas', 50),
('zeus', '2021-07-16 18:16:30', 'testststses', 51),
('zeus', '2021-07-16 18:37:48', 'teststststsss', 52),
('zeus', '2021-07-16 18:39:46', 'dfasdf', 53);

--
-- Triggers `ava`
--
DELIMITER $$
CREATE TRIGGER `new_hashtag` AFTER INSERT ON `ava` FOR EACH ROW BEGIN
	SET @i = 1;
     calc: LOOP
        IF  @i > length(NEW.Attributes) THEN 
          LEAVE calc;
        END IF;
        if substr(NEW.Attributes, @i , 6) like '#_____' then
          call 
   add_hashtag_of_ava(substr(NEW.Attributes,@i,6),NEW.ava_id,NEW.sender_user,NEW.time);
        end if;
        set  @i = @i + 1;
        
    END LOOP;
    
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `update_ava_stats` AFTER INSERT ON `ava` FOR EACH ROW INSERT INTO ava_stats(sender_user, time, Ava_id)
VALUES(new.sender_user, new.time, new.Ava_id)
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `ava_specialsigns`
--

CREATE TABLE `ava_specialsigns` (
  `ava_id` int(11) NOT NULL,
  `ava_sender_user` varchar(20) NOT NULL,
  `special_sign_id` int(11) NOT NULL,
  `attached_time` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ava_specialsigns`
--

INSERT INTO `ava_specialsigns` (`ava_id`, `ava_sender_user`, `special_sign_id`, `attached_time`) VALUES
(1, 'zeus', 1, '2021-05-29 16:24:17'),
(3, 'zeus3', 1, '2021-05-29 16:44:39'),
(4, 'zeus', 1, '2021-05-29 16:42:55'),
(5, 'zeus', 1, '2021-05-29 16:43:02'),
(6, 'zeus', 1, '2021-05-29 16:43:07'),
(50, 'zeus100', 7, '2021-07-14 18:22:08'),
(50, 'zeus100', 8, '2021-07-14 18:22:08');

-- --------------------------------------------------------

--
-- Table structure for table `ava_stats`
--

CREATE TABLE `ava_stats` (
  `sender_user` varchar(20) NOT NULL,
  `time` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `Ava_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ava_stats`
--

INSERT INTO `ava_stats` (`sender_user`, `time`, `Ava_id`) VALUES
('zeus100', '2021-07-14 16:18:04', 49),
('zeus100', '2021-07-14 18:22:08', 50),
('zeus', '2021-07-16 18:16:30', 51),
('zeus', '2021-07-16 18:37:48', 52),
('zeus', '2021-07-16 18:39:46', 53),
('zeus', '2021-07-16 19:08:55', 17);

-- --------------------------------------------------------

--
-- Table structure for table `blocks`
--

CREATE TABLE `blocks` (
  `blocker_id` varchar(20) NOT NULL,
  `blocked_id` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `blocks`
--

INSERT INTO `blocks` (`blocker_id`, `blocked_id`) VALUES
('zeus', 'zeus10'),
('zeus', 'zeus2'),
('zeus3', 'zeus'),
('zeus5', 'zeus4');

-- --------------------------------------------------------

--
-- Table structure for table `connections`
--

CREATE TABLE `connections` (
  `follower_user` varchar(20) NOT NULL,
  `following_user` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `connections`
--

INSERT INTO `connections` (`follower_user`, `following_user`) VALUES
('zeus', 'zeus2'),
('zeus', 'zeus3'),
('zeus', 'zeus4'),
('zeus', 'zeus5'),
('zeus3', 'zeus2'),
('zeus3', 'zeus4');

-- --------------------------------------------------------

--
-- Table structure for table `likes`
--

CREATE TABLE `likes` (
  `liker_user_name` varchar(20) NOT NULL,
  `liked_ava_id` int(11) NOT NULL,
  `like_time` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `likes`
--

INSERT INTO `likes` (`liker_user_name`, `liked_ava_id`, `like_time`) VALUES
('zeus10', 1, '2021-05-29 17:46:52'),
('zeus2', 3, '2021-05-29 17:46:04'),
('zeus3', 1, '2021-05-29 17:46:34'),
('zeus4', 1, '2021-05-29 17:46:43'),
('zeus5', 1, '2021-05-29 17:46:47');

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
('zeus2', 'zeus3', NULL, 10, '2021-05-29 21:37:35');

-- --------------------------------------------------------

--
-- Table structure for table `opinion`
--

CREATE TABLE `opinion` (
  `from_id` int(11) NOT NULL,
  `to_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `opinion`
--

INSERT INTO `opinion` (`from_id`, `to_id`) VALUES
(5, 2),
(6, 3),
(7, 2),
(17, 49);

-- --------------------------------------------------------

--
-- Table structure for table `special_sign`
--

CREATE TABLE `special_sign` (
  `sign` char(6) NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `special_sign`
--

INSERT INTO `special_sign` (`sign`, `id`) VALUES
('#1adsf', 8),
('#abcde', 1),
('#abcdf', 2),
('#abcdg', 3),
('#abcdh', 4),
('#abcdi', 5),
('#abcdt', 7);

-- --------------------------------------------------------

--
-- Table structure for table `user_logs`
--

CREATE TABLE `user_logs` (
  `username` varchar(20) NOT NULL,
  `log_time` timestamp NOT NULL DEFAULT current_timestamp(),
  `Type` varchar(6) NOT NULL DEFAULT 'log_in'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user_logs`
--

INSERT INTO `user_logs` (`username`, `log_time`, `Type`) VALUES
('zeus', '2021-05-28 11:27:50', 'log_in'),
('zeus', '2021-05-28 11:28:49', 'log_in'),
('zeus', '2021-05-28 11:31:41', 'logout'),
('zeus3', '2021-07-09 19:56:43', 'log_in'),
('zeus', '2021-07-09 20:21:29', 'log_in'),
('zeus3', '2021-07-09 20:22:02', 'log_in'),
('zeus', '2021-07-09 20:29:50', 'logout'),
('zeus', '2021-07-16 12:03:26', 'log_in'),
('zeus', '2021-07-16 12:17:43', 'log_in'),
('zeus', '2021-07-16 12:42:09', 'log_in'),
('zeus', '2021-07-16 12:52:25', 'log_in'),
('zeus', '2021-07-16 12:53:19', 'log_in'),
('zeus', '2021-07-16 12:56:55', 'log_in'),
('zeus', '2021-07-16 13:00:04', 'log_in'),
('zeus', '2021-07-16 13:16:11', 'log_in'),
('zeus', '2021-07-16 15:05:08', 'log_in'),
('zeus', '2021-07-16 15:13:28', 'log_in'),
('zeus', '2021-07-16 18:02:26', 'log_in'),
('zeus', '2021-07-16 18:05:13', 'log_in'),
('zeus', '2021-07-16 18:05:56', 'log_in'),
('zeus', '2021-07-16 18:06:27', 'log_in'),
('zeus', '2021-07-16 18:07:49', 'log_in');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`user_name`);

--
-- Indexes for table `account_stats`
--
ALTER TABLE `account_stats`
  ADD KEY `id` (`id`);

--
-- Indexes for table `ava`
--
ALTER TABLE `ava`
  ADD PRIMARY KEY (`Ava_id`),
  ADD KEY `sender_user` (`sender_user`);

--
-- Indexes for table `ava_specialsigns`
--
ALTER TABLE `ava_specialsigns`
  ADD PRIMARY KEY (`ava_id`,`ava_sender_user`,`special_sign_id`),
  ADD KEY `ava_id` (`ava_id`,`ava_sender_user`),
  ADD KEY `special_sign_id` (`special_sign_id`),
  ADD KEY `ava_sender_user` (`ava_sender_user`);

--
-- Indexes for table `ava_stats`
--
ALTER TABLE `ava_stats`
  ADD KEY `sender_user` (`sender_user`),
  ADD KEY `Ava_id` (`Ava_id`);

--
-- Indexes for table `blocks`
--
ALTER TABLE `blocks`
  ADD UNIQUE KEY `blocker_id_2` (`blocker_id`,`blocked_id`),
  ADD KEY `blocker_id` (`blocker_id`,`blocked_id`),
  ADD KEY `blocked_id` (`blocked_id`);

--
-- Indexes for table `connections`
--
ALTER TABLE `connections`
  ADD UNIQUE KEY `follower_user_2` (`follower_user`,`following_user`),
  ADD UNIQUE KEY `follower_user_3` (`follower_user`,`following_user`),
  ADD KEY `follower_user` (`follower_user`),
  ADD KEY `following_user` (`following_user`);

--
-- Indexes for table `likes`
--
ALTER TABLE `likes`
  ADD PRIMARY KEY (`liker_user_name`,`liked_ava_id`),
  ADD KEY `liker_user_name` (`liker_user_name`),
  ADD KEY `liked_ava_id` (`liked_ava_id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD KEY `from_id` (`from_id`),
  ADD KEY `to_id` (`to_id`),
  ADD KEY `ava_id` (`ava_id`);

--
-- Indexes for table `opinion`
--
ALTER TABLE `opinion`
  ADD KEY `from_id` (`from_id`,`to_id`),
  ADD KEY `to_id` (`to_id`);

--
-- Indexes for table `special_sign`
--
ALTER TABLE `special_sign`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `sign` (`sign`);

--
-- Indexes for table `user_logs`
--
ALTER TABLE `user_logs`
  ADD KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ava`
--
ALTER TABLE `ava`
  MODIFY `Ava_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=54;

--
-- AUTO_INCREMENT for table `special_sign`
--
ALTER TABLE `special_sign`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ava`
--
ALTER TABLE `ava`
  ADD CONSTRAINT `ava_ibfk_1` FOREIGN KEY (`sender_user`) REFERENCES `account` (`user_name`);

--
-- Constraints for table `ava_specialsigns`
--
ALTER TABLE `ava_specialsigns`
  ADD CONSTRAINT `ava_specialsigns_ibfk_1` FOREIGN KEY (`ava_id`) REFERENCES `ava` (`Ava_id`),
  ADD CONSTRAINT `ava_specialsigns_ibfk_2` FOREIGN KEY (`ava_sender_user`) REFERENCES `ava` (`sender_user`),
  ADD CONSTRAINT `ava_specialsigns_ibfk_3` FOREIGN KEY (`special_sign_id`) REFERENCES `special_sign` (`id`);

--
-- Constraints for table `blocks`
--
ALTER TABLE `blocks`
  ADD CONSTRAINT `blocks_ibfk_1` FOREIGN KEY (`blocker_id`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `blocks_ibfk_2` FOREIGN KEY (`blocked_id`) REFERENCES `account` (`user_name`);

--
-- Constraints for table `connections`
--
ALTER TABLE `connections`
  ADD CONSTRAINT `connections_ibfk_1` FOREIGN KEY (`follower_user`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `connections_ibfk_2` FOREIGN KEY (`following_user`) REFERENCES `account` (`user_name`);

--
-- Constraints for table `likes`
--
ALTER TABLE `likes`
  ADD CONSTRAINT `likes_ibfk_1` FOREIGN KEY (`liked_ava_id`) REFERENCES `ava` (`Ava_id`),
  ADD CONSTRAINT `likes_ibfk_2` FOREIGN KEY (`liker_user_name`) REFERENCES `account` (`user_name`);

--
-- Constraints for table `messages`
--
ALTER TABLE `messages`
  ADD CONSTRAINT `messages_ibfk_1` FOREIGN KEY (`from_id`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `messages_ibfk_2` FOREIGN KEY (`to_id`) REFERENCES `account` (`user_name`),
  ADD CONSTRAINT `messages_ibfk_3` FOREIGN KEY (`ava_id`) REFERENCES `ava` (`Ava_id`);

--
-- Constraints for table `opinion`
--
ALTER TABLE `opinion`
  ADD CONSTRAINT `opinion_ibfk_2` FOREIGN KEY (`to_id`) REFERENCES `ava` (`Ava_id`);

--
-- Constraints for table `user_logs`
--
ALTER TABLE `user_logs`
  ADD CONSTRAINT `user_logs_ibfk_1` FOREIGN KEY (`username`) REFERENCES `account` (`user_name`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
