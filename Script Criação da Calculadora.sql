USE myprojetos

CREATE TABLE Calculadora(
	ID INT IDENTITY PRIMARY KEY,
	valueA INT,
	valueB INT,
	operation CHAR(1),
	result VARCHAR(100),
	DtaRegistration DATETIME,
	active CHAR(1)
)



