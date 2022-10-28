# Inserimento di un FB da libreria del progetto e generazione di N Db di istanza
Semplice esempio TIA Portal Openness che esegue le seguenti operazioni:

### OBIETTIVO
- Aggancio all'istanza TIA Portal e al progetto attualmente aperto
- Inserimento dell'FB 'Motore' presente nella libreria di progetto, nella cartella Blocchi del PLC
- Richiesta tramite Console del numero di istanze da creare
- Realizzazione delle N DB di istanza con numero progressivo
- Assegnazione dell'indirizzo IP 192.168.0.11 al drive
- Creazione di una rete ethernet nel progetto
- Collegamento dei due dispositivi alla rete appena creata
- Creazione di una sottorete PROFINET assegnata al PLC S7-1513
- Assegnazione del drive alla sottorete appena creata e quindi al PLC
- Creazione di un oggetto tecnologico SpeedAxis
- Rilevamento dell'indirizzo di IO del telegramma del drive
- Assegnazione dell'oggetto tecnologico al drive

### PREREQUISITI
- Apri il progetto TIA Portal scaricabile in questa Repository
- Lancia l'applicazione Windows Console .NET Framework con all'interno il file .cs scaricato da questa Repository

### RISULTATO
![Es5](https://user-images.githubusercontent.com/108678849/198558372-a51b6ab3-3dce-401e-ab27-d1c5dae3f5fb.png)


