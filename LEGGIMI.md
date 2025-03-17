Funzione Programma: il gamemanager crea la stateMachine
Il gioco inizia e SetupBoardState si attiva e prepara la board, poi cambia a InputRegistrationState
Aspetta per l'input e poi passa a PlayerTurnState
PlayerTurnState aspetta che sia eseguito lo sparo e cambia a PuckMovingState
Il puck si muove e PuckMovingState aspetta che non si muova più
Dopo un certo numero di turni il Gioco finisce e Entra nel GamoverState dove il gioco effettivamente finisce

NOTA: il GameManager non prende conto di turni ancora, quindi finisce dopo un ciclo di tutti gli state
