import {Component, OnInit} from '@angular/core';
import {ActivatedRoute, Params} from '@angular/router';
import { faArrowLeft } from '@fortawesome/free-solid-svg-icons';
import {switchMap} from 'rxjs/operators';
import { PostsService } from 'src/app/service/post.service';

@Component({
  selector: 'app-post-page',
  templateUrl: './post-page.component.html',
  styleUrls: ['./post-page.component.scss']
})
export class PostPageComponent implements OnInit {

  post$: any
  faArrowLeft = faArrowLeft;

  constructor(
    private route: ActivatedRoute,
    private postsService: PostsService
  ) {
  }

  ngOnInit() {
    this.post$ = this.route.params
      .pipe(switchMap((params: Params) => {
        return this.postsService.getPostById(params['id'])
      }))
  }

}
