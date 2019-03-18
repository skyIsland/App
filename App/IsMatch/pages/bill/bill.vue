<template>
	<view>
		<view class="uni-padding-wrap uni-common-mt">
			<view>
				<scroll-view class="list" scroll-y>
					<ul id="example-1">
						<li v-for="item in billList" :key="item.id">
							{{ item.money }} {{ item.type }}
						</li>
					</ul>
				</scroll-view>
			</view>
		</view>
	</view>
</template>
<script>
	// import uniLoadMore from '@/components/uni-load-more/uni-load-more.vue';
	export default {

		// 		components: {
		// 			uniLoadMore
		// 		},
		data() {
			return {
				// 				loadingText: {
				// 					contentdown: '上拉加载更多',
				// 					contentrefresh: '正在加载...',
				// 					contentnomore: '没有更多数据了'
				// 				},
				// 				refreshing: false,
				// 				refreshText: '下拉可以刷新',
				billList: [{
					type: '支出',
					money: '6'
				}]
			}
		},
		onLoad: function() {
			this.getList();
		},
		methods: {
			getList() {
				uni.showLoading({
					title: '加载中'
				});
				uni.request({
					url: 'http://192.168.8.58:5000/api/bill/getlist',
					success: (result) => {
						if (result.statusCode == 200) {
							console.log(JSON.stringify(result));
							if (result.data.status == 1) {
								this.billList = this.billList.concat(result.data.data);
							}
						} else {
							console.log(JSON.stringify(`${statusCode}{result}`));
						}
					},
					fail: (ret) => {
						uni.showModal({
							title: '提示',
							content: JSON.stringify(ret)
						});
					},
					complete: () => {
						uni.hideLoading();
					}
				})
			}
		}
	}
</script>

<style>

</style>
