import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-ranking-star',
  templateUrl: './ranking-star.component.html',
  styleUrls: ['./ranking-star.component.css']
})
export class RankingStarComponent implements OnInit {

  @Input()
    currRanking = 0;
  @Output()
    setRanking: EventEmitter<number> = new EventEmitter<number>();
  rankingArray = [];
  rankingBefore = 0;

  constructor(private toatr: ToastrService ) { }

  ngOnInit(): void {
    this.rankingArray = Array(5).fill(0);
  }
//style="display: none"
  ranking(index: number){
    this.mouseEnter(index);
    this.rankingBefore = this.currRanking;
    this.setRankingStar();
  }

  mouseEnter(index: number): void{
    this.currRanking = index + 1;
  }

  mouseLeave(){
    if(this.rankingBefore !== 0)
      this.currRanking = this.rankingBefore;
    else
      this.currRanking = 0;
  }

//**Rise the event send the data back to parent*//
  setRankingStar(){
    this.setRanking.emit(this.currRanking);
  }

}
