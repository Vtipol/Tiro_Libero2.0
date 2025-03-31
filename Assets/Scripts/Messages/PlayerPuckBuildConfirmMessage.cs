public class PlayerPuckBuildConfirmMessage : IPublisherMessage {
    public Player player;
    public PlayerPuckBuildConfirmMessage(Player player){
        this.player = player;
    }


}