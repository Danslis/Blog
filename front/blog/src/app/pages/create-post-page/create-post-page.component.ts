import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { Post } from 'src/app/interfaces/postResponse';
import { PostsService } from 'src/app/service/post.service';


@Component({
  selector: 'app-create-page',
  templateUrl: './create-post-page.component.html',
  styleUrls: ['./create-post-page.component.scss']
})
export class CreatePostPageComponent implements OnInit {

  form: FormGroup;

  constructor(private postsService: PostsService,
    private router: Router) {
  }

  ngOnInit() {
    this.form = new FormGroup({
      title: new FormControl(null, Validators.required),
      text: new FormControl(null, Validators.required)
    })
  }

  submit() {
    if (this.form.invalid) {
      return
    }

    const post: Post = {
      title: this.form.value.title,
      text: this.form.value.text
    }

    this.postsService.createPost(post).subscribe((postResponse: Post) => {
      this.form.reset();
      if(postResponse != null){
        this.router.navigate(['/home']);
      }
    })
  }

}
