import redis.clients.jedis.Jedis;

import java.io.File;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        var jedis = new Jedis();
        try (Scanner scanner = new Scanner(new File("Assets\\NYSE_20210301.csv"))) {
            while (scanner.hasNextLine()) {
                var o1 = scanner.nextLine();
                var items = o1.split(",", 2);
                jedis.set(items[0], items[1]);
            }
        } catch (Exception e) {
            e.printStackTrace();
        }

        try (var scanner = new Scanner(System.in)) {
            while (true) {
                System.out.println();
                var type = scanner.next();
                switch (type) {
                    case "create" -> {
                        var key = scanner.next();
                        var value = scanner.next();
                        if (jedis.exists(key)) {
                            System.out.println("false");
                        } else {
                            jedis.set(key, value);
                            System.out.println("true");
                        }
                    }
                    case "fetch" -> {
                        var key = scanner.next();
                        if (jedis.exists(key)) {
                            System.out.println("true\n" + jedis.get(key));
                        } else {
                            System.out.println("false");
                        }
                    }
                    case "update" -> {
                        var key = scanner.next();
                        var value = scanner.next();
                        if (jedis.exists(key)) {
                            jedis.set(key, value);
                            System.out.println("true");
                        } else {
                            System.out.println("false");
                        }
                    }
                    case "delete" -> {
                        var key = scanner.next();
                        if (jedis.exists(key)) {
                            jedis.del(key);
                            System.out.println("true");
                        } else
                            System.out.println("false");
                    }
                    default -> {
                        System.out.println("Invalid Input");
                        System.exit(1);
                    }
                }
            }
        }

    }
}
