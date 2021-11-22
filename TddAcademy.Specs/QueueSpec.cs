using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace TddAcademy.Specs;

public static class QueueSpec
{
    public class A_new_queue
    {
        private FixedSizeQueue<string> cut = new();

        [Fact]
        public void is_empty() => cut.Should().BeEmpty();

        [Fact]
        public void preserves_positive_bounding_capacity() =>
            cut = new FixedSizeQueue<string>(10);

        [Fact]
        public void cannot_be_created_with_non_positive_bounding_capacity()
        {
            Action act = () => cut = new FixedSizeQueue<string>(-10);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }

    public class An_empty_queue
    {
        private readonly FixedSizeQueue<string> cut = new(10);

        [Fact]
        public void cannot_dequeue_when_empty()
        {
            Action act = () => cut.Dequeue();
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void remains_empty_when_null_enqueued()
        {
            cut.Enqueue(null);
            cut.Should().BeEmpty();
        }

        [Fact]
        public void becomes_non_empty_when_non_null_value_enqueued()
        {
            cut.Enqueue("plop");
            cut.Should().NotBeEmpty();
        }
    }

    public class A_non_empty_queue
    {
        private readonly FixedSizeQueue<string> cut = new(3);

        public A_non_empty_queue() => cut.Enqueue("1");

        public class that_is_not_full
        {
            private readonly A_non_empty_queue p = new();

            [Fact]
            public void becomes_longer_when_non_null_value_enqueued()
            {
                p.cut.Enqueue("2");
                p.cut.Count().Should().Be(2);
            }

            [Fact]
            public void becomes_full_when_enqueued_up_to_capacity()
            {
                p.cut.Enqueue("2");
                p.cut.Enqueue("3");

                p.cut.IsFull.Should().BeTrue();
            }
        }

        public class that_is_full
        {
            private readonly A_non_empty_queue p = new();

            public that_is_full()
            {
                p.cut.Enqueue("2");
                p.cut.Enqueue("3");
            }

            [Fact]
            public void ignores_further_enqueued_values()
            {
                p.cut.Enqueue("4");
                p.cut.Should().Equal("1", "2", "3");
            }

            [Fact]
            public void becomes_non_full_when_dequeued()
            {
                p.cut.Dequeue();
                p.cut.IsFull.Should().BeFalse();
            }
        }

        [Fact]
        public void dequeues_values_in_order_enqueued()
        {
            cut.Enqueue("2");
            cut.Enqueue("3");

            cut.Dequeue().Should().Be("1");
            cut.Dequeue().Should().Be("2");
            cut.Dequeue().Should().Be("3");
        }

        [Fact]
        public void remains_unchanged_when_null_enqueued()
        {
            cut.Enqueue(null);
            cut.Should().Equal("1");
        }
    }
}

internal sealed class FixedSizeQueue<T> : IEnumerable<T>
{
    private readonly Queue<T> queue;
    private readonly int capacity;

    public FixedSizeQueue(int capacity = 0)
    {
        this.capacity = capacity;
        this.queue = new Queue<T>(capacity);
    }

    public bool IsFull => this.queue.Count == this.capacity;

    public IEnumerator<T> GetEnumerator()
    {
        return this.queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T Dequeue()
    {
        return this.queue.Dequeue();
    }

    public void Enqueue(T? item)
    {
        if (item == null)
        {
            return;
        }

        if (this.queue.Count == this.capacity)
        {
            return;
        }

        this.queue.Enqueue(item);
    }
}