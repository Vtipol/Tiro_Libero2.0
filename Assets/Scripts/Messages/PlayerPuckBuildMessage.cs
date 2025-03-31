public class PlayerPuckBuildMessage : IPublisherMessage {
    public Player player;
    public PlayerPuckBuildMessage(Player player){
        this.player = player;
    }


}