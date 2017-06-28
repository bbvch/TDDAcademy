import { describe, test, expect } from "vitest";
import { Foo } from "./foo";

describe("Foo", () => {
  test("says", () => {
    const fake = "fake";
    const foo = new Foo({ say: () => fake });
    const phrase = foo.say();
    expect(phrase).toBe(`foo${fake}`);
  });
});
