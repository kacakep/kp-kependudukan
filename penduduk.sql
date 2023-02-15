-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 15, 2023 at 07:00 PM
-- Server version: 10.4.25-MariaDB
-- PHP Version: 7.4.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `penduduk`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_penduduk`
--

CREATE TABLE `data_penduduk` (
  `id_dpi` bigint(10) NOT NULL,
  `nik` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `no_kk` varchar(16) NOT NULL,
  `jk` enum('Laki laki','Perempuan') NOT NULL,
  `tgl_lahir` date NOT NULL,
  `pekerjaan` varchar(20) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `rt` varchar(4) NOT NULL,
  `rw` varchar(4) NOT NULL,
  `agama` varchar(25) NOT NULL,
  `pendidikan` varchar(25) NOT NULL,
  `username` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `data_penduduk`
--

INSERT INTO `data_penduduk` (`id_dpi`, `nik`, `nama`, `no_kk`, `jk`, `tgl_lahir`, `pekerjaan`, `alamat`, `rt`, `rw`, `agama`, `pendidikan`, `username`) VALUES
(1, '3275032910000030', 'Irfannudin Naufal Andriansyah', '3275032912300030', 'Laki laki', '2013-02-21', 'Mahasiswa', 'dfdsfsdfds', '11', '12', 'ISLAM', 'SD', 'Naufal'),
(2, '3275032910000030', 'Irfannudin Naufal Andriansyah', '3275032912300030', 'Laki laki', '2013-02-21', 'Mahasiswa', 'dfdsfsdfds', '11', '12', 'ISLAM', 'SD', 'Naufal');

-- --------------------------------------------------------

--
-- Table structure for table `kk`
--

CREATE TABLE `kk` (
  `no_kk` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `nik` varchar(16) NOT NULL,
  `jk` enum('Laki laki','Perempuan') NOT NULL,
  `tmpt_lhr` varchar(20) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `agama` enum('ISLAM','KRISTEN','KHATOLIK','HINDU','BUDHA','KONG HU CU') NOT NULL,
  `pendidikan` enum('SD','SMP','SMA','D3','D4','S1') NOT NULL,
  `pekerjaan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `kk`
--

INSERT INTO `kk` (`no_kk`, `nama`, `nik`, `jk`, `tmpt_lhr`, `tgl_lahir`, `agama`, `pendidikan`, `pekerjaan`) VALUES
('3275032912300030', 'Irfannudin Naufal Andriansyah', '3275032910000030', 'Laki laki', 'Bekasi', '2013-02-21', 'ISLAM', 'SD', 'Mahasiswa'),
('3275032923100030', 'M. Chairul Anwar', '3275032934300030', 'Perempuan', 'Bekasi', '2020-03-19', 'KRISTEN', 'SMA', 'Bisnin Ikan');

-- --------------------------------------------------------

--
-- Table structure for table `ktp`
--

CREATE TABLE `ktp` (
  `nik` varchar(16) NOT NULL,
  `nama` varchar(100) NOT NULL,
  `tgl_lahir` date NOT NULL,
  `jk` varchar(25) NOT NULL,
  `alamat` varchar(100) NOT NULL,
  `rt` varchar(4) NOT NULL,
  `rw` varchar(4) NOT NULL,
  `agama` enum('ISLAM','KRISTEN','KHATOLIK','BUDDHA','HINDU','KONG HU CU') NOT NULL,
  `stat_kawin` enum('BELUM KAWIN','KAWIN') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ktp`
--

INSERT INTO `ktp` (`nik`, `nama`, `tgl_lahir`, `jk`, `alamat`, `rt`, `rw`, `agama`, `stat_kawin`) VALUES
('3275032910000030', 'Irfannudin Naufal Andriansyah', '2013-02-21', 'Cowo', 'dfdsfsdfds', '11', '12', 'ISLAM', 'BELUM KAWIN');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(20) NOT NULL,
  `password` varchar(15) NOT NULL,
  `jabatan` enum('admin','pegawai') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `password`, `jabatan`) VALUES
('Anwar', '1', 'pegawai'),
('Hamka', '1', 'pegawai'),
('Naufal', '1', 'admin');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data_penduduk`
--
ALTER TABLE `data_penduduk`
  ADD PRIMARY KEY (`id_dpi`),
  ADD KEY `nik` (`nik`,`no_kk`),
  ADD KEY `no_kk` (`no_kk`),
  ADD KEY `username` (`username`);

--
-- Indexes for table `kk`
--
ALTER TABLE `kk`
  ADD PRIMARY KEY (`no_kk`);

--
-- Indexes for table `ktp`
--
ALTER TABLE `ktp`
  ADD PRIMARY KEY (`nik`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`username`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `data_penduduk`
--
ALTER TABLE `data_penduduk`
  ADD CONSTRAINT `data_penduduk_ibfk_1` FOREIGN KEY (`no_kk`) REFERENCES `kk` (`no_kk`),
  ADD CONSTRAINT `data_penduduk_ibfk_2` FOREIGN KEY (`nik`) REFERENCES `ktp` (`nik`),
  ADD CONSTRAINT `data_penduduk_ibfk_3` FOREIGN KEY (`username`) REFERENCES `user` (`username`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
