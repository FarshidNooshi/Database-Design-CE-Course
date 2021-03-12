import redis.clients.jedis.Jedis;

public class Main {
    public static void main(String[] args) {
        System.out.println("Hello World!");
        Jedis jedis = new Jedis("localhost");
        jedis.set("events/city/rome", "32,15,223,828");
        String cachedResponse = jedis.get("events/city/rome");
        System.out.println(cachedResponse);
    }
}
