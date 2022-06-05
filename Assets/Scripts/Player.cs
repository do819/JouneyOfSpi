[System.Serializable]
public class Player
{
    public int speed;
    public int level;
    public int jump;
    public float[] position;
    
    public Player()
    {
        this.speed = 3;
        this.level = 1;
        this.jump = 80;
        this.position = new float[3];
        this.position[0] = 0f;
        this.position[1] = 0f;
        this.position[2] = 0f;
    }

    public Player(Player player)
    {
        this.speed = player.speed;
        this.level = player.level;
        this.jump = player.jump;
        this.position = player.position;
    }
}
