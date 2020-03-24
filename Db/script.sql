-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema medical
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema medical
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `medical` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `medical` ;

-- -----------------------------------------------------
-- Table `medical`.`categorie`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`categorie` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(45) NULL,
  `libellé` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `medical`.`materiel`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`materiel` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `reference` VARCHAR(45) NULL,
  `description` VARCHAR(45) NULL,
  `date_achat` DATE NULL,
  `prix_loc` DOUBLE NULL,
  `categorie_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_materiel_categorie_idx` (`categorie_id` ASC) VISIBLE,
  CONSTRAINT `fk_materiel_categorie`
    FOREIGN KEY (`categorie_id`)
    REFERENCES `medical`.`categorie` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `medical`.`client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`client` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `prenom` VARCHAR(45) NULL,
  `telephone` VARCHAR(45) NULL,
  `type` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `medical`.`adresse`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`adresse` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `numero` VARCHAR(45) NULL,
  `rue` VARCHAR(45) NULL,
  `code_postal` VARCHAR(45) NULL,
  `ville` VARCHAR(45) NULL,
  `client_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_adresse_client1_idx` (`client_id` ASC) VISIBLE,
  CONSTRAINT `fk_adresse_client1`
    FOREIGN KEY (`client_id`)
    REFERENCES `medical`.`client` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `medical`.`fiche`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`fiche` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `date` DATE NULL,
  `client_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_panier_client1_idx` (`client_id` ASC) VISIBLE,
  CONSTRAINT `fk_panier_client1`
    FOREIGN KEY (`client_id`)
    REFERENCES `medical`.`client` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `medical`.`materiel_has_fiche`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `medical`.`materiel_has_fiche` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `materiel_id` INT NOT NULL,
  `fiche_id` INT NOT NULL,
  `date_debut` DATE NULL,
  `date_fin` DATE NULL,
  INDEX `fk_materiel_has_fiche_fiche1_idx` (`fiche_id` ASC) VISIBLE,
  INDEX `fk_materiel_has_fiche_materiel1_idx` (`materiel_id` ASC) VISIBLE,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_materiel_has_fiche_materiel1`
    FOREIGN KEY (`materiel_id`)
    REFERENCES `medical`.`materiel` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_materiel_has_fiche_fiche1`
    FOREIGN KEY (`fiche_id`)
    REFERENCES `medical`.`fiche` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
