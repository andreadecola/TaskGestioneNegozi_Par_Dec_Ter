DROP TABLE IF EXISTS Ordine_Prodotto;
DROP TABLE IF EXISTS Variazione;
DROP TABLE IF EXISTS Prodotto;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS Ordine;
DROP TABLE IF EXISTS Utente;

CREATE TABLE Utente (
    utenteID INT PRIMARY KEY IDENTITY (1,1),
    nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
    email VARCHAR(250)NOT NULL,
	pass VARCHAR(250)NOT NULL,
	UNIQUE (email,pass)
);

CREATE TABLE Ordine (
    ordineID INT PRIMARY KEY IDENTITY (1,1),
    utenteRIF INT,
    data_ordine DATE,
    stato VARCHAR(250) CHECK (stato in ('Effettuato','Rifiutato')),
    FOREIGN KEY (utenteRIF) REFERENCES Utente(utenteID)
);

CREATE TABLE Categoria (
    categoriaID INT PRIMARY KEY IDENTITY (1,1),
    nome VARCHAR(250)   
);

CREATE TABLE Prodotto (
    prodottoID INT PRIMARY KEY IDENTITY (1,1),
    nome VARCHAR(250),
    descrizione TEXT,
	categoriaRIF INT,
    FOREIGN KEY (categoriaRIF) REFERENCES Categoria(categoriaID)
);
CREATE TABLE Variazione (
    variazioneID INT PRIMARY KEY IDENTITY (1,1),
    prodottoRIF INT,
    colore VARCHAR(50),
    taglia VARCHAR(50),
    quantità INT,
    prezzo_pieno DECIMAL(10, 2),
    prezzo_offerta DECIMAL(10, 2),
    data_inizio_offerta DATE,
    data_fine_offerta DATE,
    FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID)
);

CREATE TABLE Ordine_Prodotto (
    ordineRIF INT,
    prodottoRIF INT,
    variazioneRIF INT,
    quantità INT,
    PRIMARY KEY (ordineRIF, prodottoRIF, variazioneRIF),
    FOREIGN KEY (ordineRIF) REFERENCES Ordine(ordineID),
    FOREIGN KEY (prodottoRIF) REFERENCES Prodotto(prodottoID),
    FOREIGN KEY (variazioneRIF) REFERENCES Variazione(variazioneID)
);
INSERT INTO Utente (nome, cognome, email, pass) VALUES 
	('Mario', 'Rossi', 'mario@rossi.com', 'qwer1234'),
    ('Luigi', 'Bianchi', 'luigi@bianchi.com', 'qwer1235'),
    ('Giuseppe', 'Verdi', 'giuseppe@verdi.com', 'qwer1236'),
    ('Anna', 'Bruno', 'anna@bruno.com', 'qwer1237'),
    ('Maria', 'Russo', 'maria@russo.com', 'qwer1238');

INSERT INTO Ordine (utenteRIF, data_ordine, stato) VALUES
     (1, '2024-03-01', 'Effettuato'),
     (2, '2024-03-02', 'Rifiutato'),
     (3, '2024-03-03', 'Effettuato'),
     (4, '2024-03-04', 'Rifiutato'),
     (5, '2024-03-05', 'Effettuato');


INSERT INTO Categoria (nome) VALUES
     ('Uomo'),
     ('Donna'),
     ('Bambino'),
     ('Accessori'),
     ('Calzature');


INSERT INTO Prodotto (nome, descrizione, categoriaRIF)VALUES
     ('T-shirt', 'T-shirt in cotone', 1),
     ('Pantaloni', 'Pantaloni in denim', 1),
     ('Cappello', 'Cappello in lana', 4),
     ('Vestito', 'Vestito estivo', 2),
     ('Stivali', 'Stivale in pelle', 5);

INSERT INTO Variazione (prodottoRIF, colore, taglia, quantità, prezzo_pieno, prezzo_offerta, data_inizio_offerta, data_fine_offerta)VALUES
	 (1, 'Blu', 'M', 10, 19.99, 14.99, '2024-03-01', '2024-03-27'),
     (2, 'Nero', 'L', 5, 39.99, 29.99, '2024-03-01', '2024-03-27'),
     (3, 'Rosso', 'Unica', 15, 9.99, 7.99, '2024-03-01', '2024-03-27'),
     (4, 'Bianco', 'S', 20, 29.99, 24.99, '2024-03-01', '2024-03-27'),
     (5, 'Beige', '38', 8, 24.99, 19.99, '2024-03-01', '2024-03-27');

INSERT INTO Ordine_Prodotto (ordineRIF, prodottoRIF, variazioneRIF, quantità) VALUES
     (1, 1, 1, 2),
     (2, 2, 2, 1),
     (3, 3, 3, 3),
     (4, 4, 4, 1),
     (5, 5, 5, 2);


SELECT * FROM Utente;