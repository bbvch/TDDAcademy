package tddacademy;

public class Foo {

    private final Bar bar;

    public Foo(Bar bar) {

        this.bar = bar;
    }

    public String say() {
        return "foo" + this.bar.say();
    }
}
