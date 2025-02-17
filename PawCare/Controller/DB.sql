-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 17, 2025 at 06:50 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `paw_care`
--

-- --------------------------------------------------------

--
-- Table structure for table `animal`
--

CREATE TABLE `animal` (
  `animal_id` char(40) NOT NULL,
  `animal_name` varchar(100) NOT NULL,
  `gender` enum('Jantan','Betina') NOT NULL,
  `age` int(11) NOT NULL,
  `image_path` varchar(100) NOT NULL,
  `category_id` char(40) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `update_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Dumping data for table `animal`
--

INSERT INTO `animal` (`animal_id`, `animal_name`, `gender`, `age`, `image_path`, `category_id`, `created_at`, `update_at`) VALUES
('0cb4f739-a8dc-44b3-8058-072d686c6c49', 'tes 12', 'Jantan', 11, 'Image\\292a0408-bd28-4a78-a61a-35a90f9a65f2.png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 17:39:32', '2025-02-17 17:39:32'),
('1fb1120e-219f-41bc-9ca8-8cee33c569b0', 'tes 1', 'Jantan', 11, 'Image\\character (79).png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 14:48:01', '2025-02-17 17:16:08'),
('6710fb84-ebc0-49e0-8777-923a7c86a2eb', 'tes u dan insert 1', 'Jantan', 111, 'Image\\a73ad075-bec5-40d4-8c5e-e9a5f9a8a6f5.png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 17:38:15', '2025-02-17 17:38:15'),
('9731b2bf-9464-43eb-94b0-7b5cd6b6764f', 'tes 234', 'Betina', 123, 'Image\\6bee5854-1f6c-4265-af10-c7b7b3391832.png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 15:50:56', '2025-02-17 17:16:14'),
('a7bc2e6f-578b-4a42-94cf-cb8dd6356cdb', 'tes 4', 'Jantan', 12, 'Image\\95ba742e-205a-4604-a371-d551a8ae044c.png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 15:28:35', '2025-02-17 17:16:20'),
('b4475c63-fc3a-411a-81b3-33ca31f2ccd6', 'tes 2', 'Jantan', 123, 'Image\\ddfe4f85-1347-4907-97b3-db960e93e406.png', '3c01b3b5-1c5e-4c49-88cf-4804eecb0f37', '2025-02-17 14:54:25', '2025-02-17 17:16:25');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`animal_id`),
  ADD KEY `category_id` (`category_id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `animal`
--
ALTER TABLE `animal`
  ADD CONSTRAINT `animal_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `animal_category` (`category_id`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
