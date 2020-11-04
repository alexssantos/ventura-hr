import { Injectable } from '@angular/core';
import { trigger, transition, query as q, stagger, animateChild, state, style, animate, AnimationTriggerMetadata, group, animation, sequence } from '@angular/animations';

//soluçõa para @itemTag retornar zero itens na query.
const query = (str, animes, opts = { optional: true }) => q(str, animes, opts);


@Injectable({
	providedIn: 'root'
})
export class AnimationService {

	public static TAG_FLIP = 'FlipAnimation';
	public static TAG_FACE_IN = 'FadeInAnimation';

	public static flipTrigger() {

		return trigger(this.TAG_FLIP, [

			state('FRONT', style({
				transform: 'rotateY(0)',
				display: 'block',
				opacity: 1,
			})),
			state('BACK', style({
				transform: 'rotateY(180deg)',
				backfaceVisibility: 'hidden',
				display: 'none',
				opacity: 0,
			})),
			transition('FRONT <=> BACK', animate('.6s ease-in'))
		])
	}

	public static fadeInTrigger() {

		return trigger(this.TAG_FACE_IN, [

			transition(':enter', [
				style({
					transform: 'translateX(100px)',
					//display: 'none',
					opacity: 0,
				}),

				animate('1s 0.2s ease-in',
					style({
						transform: 'translateX(0px)',
						//display: 'block',
						opacity: 1
					}))
			]),

			transition(':leave', [
				style({
					//transform: 'translateX(0px)',
					display: 'block',
					//opacity: 1
				}),
				animate('1s ease-in',
					style({
						//transform: 'translateX(-50px)',
						display: 'none',
						//opacity: 0
					}))
			])
		])
	}
}

// translateX(0px)