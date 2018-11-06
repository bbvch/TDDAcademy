export interface TennisScorer {
    scorePlayerA(): void;
    scorePlayerB(): void;
    readonly Score: string;
}