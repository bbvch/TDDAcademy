plugins {
    // Apply the java-library plugin for API and implementation separation.
    `java-library`
    // user-friendly test reports
    id("com.adarshr.test-logger") version "4.0.0"
}

repositories {
    // Use Maven Central for resolving dependencies.
    mavenCentral()
}

dependencies {
    // Use JUnit Jupiter for testing.
    testImplementation("org.junit.jupiter:junit-jupiter:6.1.3")
    // and Mockito for faking
    testImplementation("org.mockito:mockito-core:5.+")
    testImplementation("org.mockito:mockito-junit-jupiter:5.+")
    // plus Cucumber for BDD
    testImplementation("io.cucumber:cucumber-java:8.0.4")
    testImplementation("io.cucumber:cucumber-junit-platform-engine:8.0.4")
    testImplementation("org.junit.platform:junit-platform-suite")
}

tasks.named<Test>("test") {
    // Use JUnit Platform for unit tests.
    useJUnitPlatform()
    systemProperty("cucumber.junit-platform.naming-strategy", "long")
    jvmArgs("-Xshare:off")
    failOnNoDiscoveredTests = false
}