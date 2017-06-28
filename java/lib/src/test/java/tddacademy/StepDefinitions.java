package tddacademy;

import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;

import static org.junit.jupiter.api.Assertions.*;

public class StepDefinitions {
    private final Foo foo = new Foo(new BarImpl());

    private String greeting;

    @When("foo says something")
    public void foo_says_something() {
        this.greeting = this.foo.say();
    }

    @Then("foo should say {string}")
    public void foo_should_say(String expected) {
        assertEquals(expected, this.greeting);
    }
}
