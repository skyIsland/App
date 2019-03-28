<template>
	<view>
		<view class="uni-padding-wrap uni-common-mt">
			<form @submit="formSubmit" @reset="formReset">
				<view class="uni-form-item uni-column">
					<view class="title">摘要</view>
					<input class="uni-input" name="summary" placeholder="变动摘要" />
				</view>
				<view class="uni-form-item uni-column">
					<view class="title">变动类型</view>
					<radio-group name="type">
                        <label>
                            <radio value="1" />收入
                        </label>
                        <label>
                            <radio value="2" checked="true"/>支出
                        </label>
                    </radio-group>
				</view>
				<view class="uni-form-item uni-column">
					<view class="title">金额</view>
					<input class="uni-input" name="money" placeholder="变动金额" />
				</view>
				<view class="uni-btn-v">
					<button formType="submit">提交</button>
				</view>
			</form>
		</view>
	</view>
</template>

<script>
	export default {
		data() {
			return {

			};
		},
		methods: {
			formSubmit: function(e) {
				console.log('form发生了submit事件，携带数据为：' + JSON.stringify(e.detail.value))
			},
		}
	}
</script>

<style>

</style>
