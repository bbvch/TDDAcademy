package tddacademy;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

class FooTest {
    final Foo testee;
    final Bar barFake;

    FooTest()
    {
        this.barFake = mock();
        testee = new Foo(this.barFake);
    }

    @Test void say() {
        final var barReturn = "fake";
        final var fooReturn = "foo";
        when(barFake.say()).thenReturn(barReturn);

        final var actual = testee.say();

        assertEquals(fooReturn + barReturn, actual);
    }
}
