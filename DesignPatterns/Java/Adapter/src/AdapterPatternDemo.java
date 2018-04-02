public class AdapterPatternDemo {
    public static void main(String[] args) {

        AudioPlayer audioPlayer = new AudioPlayer();

        audioPlayer.play("mp3", "Fly On");
        audioPlayer.play("mp4", "Yellow Brick Road");
        audioPlayer.play("vlc", "Songs for March");
        audioPlayer.play("mkv", "Often");
    }
}
