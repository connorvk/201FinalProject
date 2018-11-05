CREATE DATABASE Info;
USE Info;
CREATE TABLE Userinfo(
	SaveID INT(11) AUTO_INCREMENT PRIMARY key,
	Username VARCHAR(255),
    HashedPassword VARCHAR(255)
);

CREATE TABLE Monster(
	MonsterID INT(11) AUTO_INCREMENT PRIMARY key,
	MonsterName VARCHAR(255),
    HP INT(11),
    Attack INT(11)
);

CREATE TABLE Inventory(
	MonterType VARCHAR(255),
    Monstername VARCHAR(255),
    CurrentHP INT(11)
);