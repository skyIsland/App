<template>
	<view>
		<view class="uni-padding-wrap uni-common-mt">
			<view>
				<scroll-view class="list" scroll-y>
					<ul id="example-1">
						<li v-for="item in items" :key="item.id">
							{{ item.money }}
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
					url: 'http://localhost:52013/api/bill/getlist',
					success: (result) => {
						if (result.statusCode == 1) {
							this.billList.concat(result.data);
						} else {
							let msg = result.Message;
							uni.showToast({
								title: msg,
								duration: 2000
							});
						}
					},
					fail: (ret) => {
						uni.showModal({
							title: '提示',
							content: ret.errMsg
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
